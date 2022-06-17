using RunSynopsis.Server.Auth.Entities;

namespace RunSynopsis.Server.Auth
{
    public interface IUserCache
    {
        Task<bool> HasEntryAsync(string key);

        Task<User> RetrieveAsync(string key);

        Task StoreAsync(User user);

        Task DeleteAsync(string key);
    }
}