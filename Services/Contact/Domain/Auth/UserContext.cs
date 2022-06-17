using RunSynopsis.Domain.Auth.Entities;
using RunSynopsis.Domain.Auth.Exceptions;

namespace RunSynopsis.Domain.Auth
{
    internal class UserContext : IUserContext
    {
        private User? _user;

        public User? GetUser() => _user;

        public void SetUser(User? user) => _user = user;

        public void Authorize(Permission? permission)
        {
            var user = GetUser();

            if (user is null)
                throw new UserAuthenticationException("User is not signed in");

            if (user.IsBanned || !user.IsVerified)
                throw new UserAuthenticationException("User is banned or not verified");

            if (permission is null)
                return;

            var found = user.Permissions
                .Any(x => x.Type == permission.Type && x.Value == permission.Value);

            if (!found)
                throw new UserAuthorizationException($"User authorization failure - {permission.Type}.{permission.Value}");
        }

        public void Authorize<TEnum>(TEnum permission)
        {
            var flag = new Permission(typeof(TEnum).Name, permission!.ToString()!);

            Authorize(flag);
        }
    }
}