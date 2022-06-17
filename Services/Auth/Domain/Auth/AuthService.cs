using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RunSynopsis.Domain.Auth.Database;
using RunSynopsis.Domain.Auth.Entities;
using RunSynopsis.Domain.Auth.Events;
using RunSynopsis.Domain.Auth.Exceptions;
using RunSynopsis.Domain.Auth.Payloads;
using RunSynopsis.Domain.Auth.Ports;
using RunSynopsis.Domain.Auth.Validators;

namespace RunSynopsis.Domain.Auth
{
    internal class AuthService : IAuthService
    {
        private readonly IHasher _hasher;

        private readonly ITokenizer _tokenizer;

        private readonly AuthDbContext _context;

        private readonly IUserContext _userContext;

        private readonly AuthConfiguration _configuration;

        private readonly NewUserValidator _newUserValidator;

        private readonly IMediator _mediator;

        public AuthService(
            IDbContextFactory<AuthDbContext> contextFactory,
            IHasher hasher,
            ITokenizer tokenizer,
            IUserContext userContext,
            NewUserValidator newUserValidator,
            IOptions<AuthConfiguration> configuration,
            IMediator mediator)
        {
            _hasher = hasher;
            _tokenizer = tokenizer;
            _userContext = userContext;
            _newUserValidator = newUserValidator;
            _context = contextFactory.CreateDbContext();
            _configuration = configuration.Value;
            _mediator = mediator;
        }

        public IEnumerable<User> GetUsers()
        {
            _userContext.Authorize(AuthPermission.ListUsers);

            return _context.Users.AsNoTracking();
        }

        public IEnumerable<Permission> GetPermissions()
        {
            return _context.Permissions.AsNoTracking();
        }

        public async Task<User?> GetUserByIdAsync(long id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<Token> SignInAsync(string username, string password)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(x => x.Username == username);

            if (user is null)
                throw new UserAuthenticationException("User not found");

            var hashedPassword = _hasher.Create(password);

            if (!user.IsVerified)
                throw new UserAuthenticationException("User is not verified");

            if (user.Password != hashedPassword)
                throw new UserAuthenticationException("Password mismatch");

            if (user.IsBanned)
                throw new UserAuthenticationException("User is banned");

            user.LastSeenAt = DateTime.UtcNow;

            var ttl = TimeSpan.FromSeconds(_configuration.TokenTtl[TokenType.Session]);
            var token = await _tokenizer.CreateAsync(user, TokenType.Session, ttl);

            await _context.SaveChangesAsync();

            return token;
        }

        public async Task SignUpAsync(
            string nickname,
            string username,
            string password,
            string mail)
        {
            var hasDuplicate = await _context.Users
                .Where(x => x.Username == username
                    || x.Nickname == nickname
                    || x.Mail == mail)
                .AnyAsync();

            if (hasDuplicate)
                throw new UserValidationException("User credentials are not unique");

            var user = new User(nickname, username, _hasher.Create(password), mail, null!);

            var validation = await _newUserValidator.ValidateAsync(user);

            if (!validation.IsValid)
            {
                var errorMessage = validation.Errors[0].ErrorMessage;

                throw new UserValidationException(errorMessage);
            }

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            var ttl = TimeSpan.FromSeconds(_configuration.TokenTtl[TokenType.Verification]);
            
            var token = await _tokenizer.CreateAsync(user, TokenType.Verification, ttl);

            await _mediator.Publish(new AuthUserSignedUp(user, token));
        }

        public async Task<Ban> BanAsync(User user, string reason, TimeSpan? duration)
        {
            _userContext.Authorize(AuthPermission.BanUsers);

            var admin = _userContext.GetUser()!;
            var ban = new Ban(user, admin, reason, duration);

            admin.GivenBans.Add(ban);
            user.ReceivedBans.Add(ban);

            await _context.SaveChangesAsync();

            return ban;
        }

        public async Task<Ban> BanAsync(long userId, string reason, TimeSpan? duration)
        {
            var user = (await _context.Users.FindAsync(userId))!;

            return await BanAsync(user, reason, duration);
        }

        public async Task UnbanAsync(Ban ban)
        {
            _userContext.Authorize(AuthPermission.UnbanUsers);

            ban.ExpiresAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        public async Task UnbanAsync(long banId)
        {
            var ban = (await _context.Bans.FindAsync(banId))!;

            await UnbanAsync(ban);
        }

        public async Task StorePermissionsAsync(Permission permission)
        {
            var isDuplicate = await _context.Permissions
                .AnyAsync(x => x.Type == permission.Type && x.Value == permission.Value);

            if (isDuplicate)
                return;

            await _context.AddAsync(permission);
            await _context.SaveChangesAsync();
        }

        public async Task StorePermissionsAsync(string type, string value)
        {
            var permission = new Permission(type, value);

            await StorePermissionsAsync(permission);
        }

        public async Task StorePermissionsAsync(string type, IEnumerable<string> values)
        {
            var entries = values
                .Select(value => new Permission(type, value))
                .ToList();

            foreach (var entry in entries)
                await StorePermissionsAsync(entry);
        }

        public async Task StorePermissionsAsync<TEnum>(IEnumerable<TEnum> permissions) where TEnum : Enum
        {
            var type = typeof(TEnum).Name;

            var entries = permissions
                .Select(permission => new Permission(type, permission.ToString()))
                .ToList();

            foreach (var entry in entries)
                await StorePermissionsAsync(entry);
        }

        public async Task VerifyUserAsync(string value)
        {
            var token = (await _tokenizer.RetrieveAsync(value))!;
            var user = (await _context.Users.FindAsync(token.UserId))!;

            user.IsVerified = true;

            await _tokenizer.ExpireNowAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task GrantAsync(User user, Permission permission)
        {
            _userContext.Authorize(AuthPermission.ManagePermissions);

            user.Permissions.Add(permission);

            await _context.SaveChangesAsync();
        }

        public async Task GrantAsync(long userId, string type, string value)
        {
            var user = (await _context.Users.FindAsync(userId))!;

            var permission = await _context.Permissions
                .FirstAsync(x => x.Type == type && x.Value == value);

            await GrantAsync(user, permission);
        }

        public async Task RevokeAsync(User user, Permission permission)
        {
            _userContext.Authorize(AuthPermission.ManagePermissions);

            user.Permissions.Remove(permission);

            await _context.SaveChangesAsync();
        }

        public async Task RevokeAsync(long userId, string type, string value)
        {
            var user = (await _context.Users.FindAsync(userId))!;

            var entry = await _context.Permissions
                .FirstAsync(x => x.Type == type && x.Value == value);

            await RevokeAsync(user, entry);
        }

        public async Task UpdateUserAsync(User user, UpdateUserRequest request)
        {
            user.AvatarUrl = request.AvatarUrl ?? user.AvatarUrl;
            user.HomepageUrl = request.HomepageUrl ?? user.HomepageUrl;
            user.Bio = request.Bio ?? user.Bio;

            var password = request.Password;

            if (password is not null)
                password = _hasher.Create(password);

            user.Password = password ?? user.Password;

            await _context.SaveChangesAsync();
            await _mediator.Publish(new AuthUserUpdated(user));
        }

        public async Task UpdateUserAsync(long userId, UpdateUserRequest request)
        {
            var user = (await _context.Users.FindAsync(userId))!;

            await UpdateUserAsync(user, request);
        }
    }
}