using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Domain.Auth.Ports
{
    public interface ITokenizer
    {
        Task<Token> CreateAsync(User user, TokenType type, TimeSpan? ttl = null);

        Task<Token?> RetrieveAsync(string value);

        Task ExpireNowAsync(string value);
    }
}