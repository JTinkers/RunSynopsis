using RunSynopsis.Domain.Auth.Entities;
using RunSynopsis.Domain.Auth.Ports;
using System.Text;

namespace RunSynopsis.Application.Auth.Ports
{
    internal class Tokenizer : ITokenizer
    {
        private readonly ITokenCache _cache;

        public Tokenizer(ITokenCache cache)
        {
            _cache = cache;
        }

        public async Task<Token> CreateAsync(User user, TokenType type, TimeSpan? ttl = null)
        {
            var token = new Token(user, type, Generate());

            await _cache.StoreAsync(token, ttl);

            return token;
        }

        public Task<Token?> RetrieveAsync(string value)
        {
            return _cache.RetrieveAsync(value);
        }

        public async Task ExpireNowAsync(string value)
        {
            await _cache.ExpireAsync(value);
        }

        private static string Generate()
        {
            var token = Guid.NewGuid().ToString();
            var bytes = Encoding.Default.GetBytes(token);

            return Convert.ToBase64String(bytes);
        }
    }
}