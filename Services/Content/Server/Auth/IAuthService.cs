using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Server.Auth
{
    public interface IAuthService
    {
        Task StorePermissionAsync<TEnum>(TEnum permission) where TEnum : Enum;

        Task<User?> GetUserByIdAsync(long id);
    }
}