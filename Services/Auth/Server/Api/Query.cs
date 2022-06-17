using RunSynopsis.Domain.Auth;
using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Server.Api
{
    public class Query
    {
        public IQueryable<User> GetUsers(IAuthService service)
        {
            return service
                .GetUsers()
                .AsQueryable();
        }

        public IQueryable<Permission> GetPermissions(IAuthService service)
        {
            return service
                .GetPermissions()
                .AsQueryable();
        }

        public async Task<User?> GetUserByIdAsync(IAuthService service, [ID] long id)
        {
            return await service.GetUserByIdAsync(id);
        }

        public User? GetMe(IUserContext userContext)
        {
            return userContext.GetUser();
        }
    }
}