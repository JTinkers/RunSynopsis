using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Application.Auth.Ports
{
    internal interface ITokenCache
    {
        Task StoreAsync(Token token, TimeSpan? ttl);

        Task<Token?> RetrieveAsync(string key);

        Task ExpireAsync(string key);
    }
}