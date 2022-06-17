using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Server.Auth
{
    public interface IAuthCache
    {
        Task<User?> GetUserByIdAsync(long id);

        Task<bool> UserExistsAsync(long id);

        Task StoreUserAsync(User user);

        Task DeleteUserAsync(long id);
    }
}