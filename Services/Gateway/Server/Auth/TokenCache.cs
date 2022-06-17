using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RunSynopsis.Server.Auth.Entities;
using StackExchange.Redis;

namespace RunSynopsis.Server.Auth
{
    public class TokenCache : ITokenCache
    {
        private readonly IDatabase _database;

        private readonly TokenCacheConfiguration _configuration;

        public TokenCache(
            IConnectionMultiplexer redis,
            IOptions<TokenCacheConfiguration> configuration)
        {
            _database = redis.GetDatabase();
            _configuration = configuration.Value;
        }

        public async Task<bool> HasEntryAsync(string key)
        {
            key = GetKey(key);

            return await _database.KeyExistsAsync(key);
        }

        public async Task<Token> RetrieveAsync(string key)
        {
            key = GetKey(key);

            var serialized = await _database.StringGetAsync(key);
            var deserialized = JsonConvert.DeserializeObject<Token>(serialized);

            return deserialized!;
        }

        public async Task StoreAsync(Token token)
        {
            var key = GetKey(token.Value);
            var expiration = GetExpiration();

            var serialized = JsonConvert.SerializeObject(token);

            await _database.StringSetAsync(
                key,
                serialized,
                expiration,
                When.NotExists,
                CommandFlags.FireAndForget);
        }

        public async Task DeleteAsync(string key)
        {
            key = GetKey(key);

            await _database.StringGetDeleteAsync(key);
        }

        private string GetKey(string key)
        {
            return string.Format(_configuration.Key, key);
        }

        private TimeSpan GetExpiration()
        {
            return TimeSpan.FromSeconds(_configuration.Expiration);
        }
    }
}