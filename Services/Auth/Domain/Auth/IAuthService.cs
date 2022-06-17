using RunSynopsis.Domain.Auth.Entities;
using RunSynopsis.Domain.Auth.Payloads;

namespace RunSynopsis.Domain.Auth
{
    public interface IAuthService
    {
        IEnumerable<User> GetUsers();

        IEnumerable<Permission> GetPermissions();

        Task<User?> GetUserByIdAsync(long id);

        Task SignUpAsync(string nickname, string username, string password, string mail);

        Task<Token> SignInAsync(string username, string password);

        Task UpdateUserAsync(User user, UpdateUserRequest request);

        Task UpdateUserAsync(long userId, UpdateUserRequest request);

        Task<Ban> BanAsync(User user, string reason, TimeSpan? duration);

        Task<Ban> BanAsync(long userId, string reason, TimeSpan? duration);

        Task UnbanAsync(Ban ban);

        Task UnbanAsync(long banId);

        Task VerifyUserAsync(string value);

        Task StorePermissionsAsync(Permission permission);

        Task StorePermissionsAsync(string type, string value);

        Task StorePermissionsAsync<TEnum>(IEnumerable<TEnum> permissions) where TEnum : Enum;

        Task StorePermissionsAsync(string type, IEnumerable<string> values);

        Task GrantAsync(User user, Permission permission);

        Task GrantAsync(long userId, string type, string value);

        Task RevokeAsync(User user, Permission permission);

        Task RevokeAsync(long userId, string type, string value);
    }
}