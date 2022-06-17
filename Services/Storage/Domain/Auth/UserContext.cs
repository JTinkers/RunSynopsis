using RunSynopsis.Domain.Auth.Entities;
using RunSynopsis.Domain.Auth.Exceptions;

namespace RunSynopsis.Domain.Auth
{
    internal class UserContext : IUserContext
    {
        private User? _user;

        public User? GetUser() => _user;

        public void SetUser(User? user) => _user = user;

        public void Authorize<TEnum>(TEnum flag)
        {
            var user = GetUser();

            if (user is null)
                throw new UserAuthenticationException("User is not signed in");

            if (user.IsBanned || !user.IsVerified)
                throw new UserAuthenticationException("User is banned or not verified");

            var type = typeof(TEnum).Name;
            var value = flag!.ToString();

            var found = user.Permissions.Any(x => x.Type == type && x.Value == value);

            if (!found)
                throw new UserAuthorizationException($"User authorization failure. Missing {type}.{value} permission");
        }
    }
}