using RunSynopsis.Server.Auth.Entities;

namespace RunSynopsis.Server.Auth
{
    public interface ITokenCache
    {
        Task<bool> HasEntryAsync(string key);

        Task<Token> RetrieveAsync(string key);

        Task StoreAsync(Token token);

        Task DeleteAsync(string key);
    }
}