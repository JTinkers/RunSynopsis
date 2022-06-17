using Newtonsoft.Json;
using RunSynopsis.Application.Auth.Ports.Configuration;
using RunSynopsis.Domain.Auth.Entities;
using StackExchange.Redis;

namespace RunSynopsis.Application.Auth.Ports
{
    internal class TokenCache : ITokenCache
    {
        private readonly TokenCacheConfiguration _configuration;

        private readonly IDatabase _database;

        public TokenCache(
            IConnectionMultiplexer redis,
            TokenizerConfiguration configuration)
        {
            _database = redis.GetDatabase();
            _configuration = configuration.Cache;
        }

        public async Task StoreAsync(Token token, TimeSpan? ttl)
        {
            var settings = GetSerializerSettings();
            var serialized = JsonConvert.SerializeObject(token, settings);

            await _database.StringSetAsync(
                GetKey(token.Value),
                serialized,
                ttl,
                When.NotExists,
                CommandFlags.FireAndForget);
        }

        public async Task<Token?> RetrieveAsync(string key)
        {
            if (!await _database.KeyExistsAsync(GetKey(key)))
                return null;

            var serialized = await _database.StringGetWithExpiryAsync(GetKey(key));
            var deserialized = JsonConvert.DeserializeObject<Token>(serialized.Value!)!;

            deserialized.Value = key;

            return deserialized;
        }

        public async Task ExpireAsync(string key)
        {
            await _database.KeyExpireAsync(
                GetKey(key),
                TimeSpan.Zero,
                CommandFlags.FireAndForget);
        }

        private string GetKey(string key)
        {
            return string.Format(_configuration.Key, key);
        }

        private JsonSerializerSettings GetSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }
    }
}