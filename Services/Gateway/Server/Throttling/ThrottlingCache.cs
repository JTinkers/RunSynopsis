using Microsoft.Extensions.Options;
using RunSynopsis.Server.Throttling.Configuration;
using StackExchange.Redis;

namespace RunSynopsis.Server.Throttling
{
    public class ThrottlingCache : IThrottlingCache
    {
        private const string CACHE_KEY = "throttling:tracker:{0}";

        private readonly IDatabase _database;

        private readonly ThrottlingCacheConfiguration _configuration;

        public ThrottlingCache(
            IConnectionMultiplexer redis,
            IOptions<ThrottlingConfiguration> configuration)
        {
            _database = redis.GetDatabase();
            _configuration = configuration.Value.Cache;
        }

        public async Task<bool> HasEntryAsync(string key)
        {
            return await _database.KeyExistsAsync(GetKey(key));
        }

        public async Task<int> RetrieveAsync(string key)
        {
            return int.Parse(await _database.StringGetAsync(GetKey(key)));
        }

        public async Task StoreAsync(string key)
        {
            await _database.StringSetAsync(GetKey(key), 0,
                TimeSpan.FromSeconds(_configuration.Expiration),
                When.NotExists,
                CommandFlags.FireAndForget);
        }

        public async Task IncrementAsync(string key)
        {
            await _database.StringIncrementAsync(GetKey(key), 1,
                CommandFlags.FireAndForget);
        }

        private string GetKey(string key)
        {
            return string.Format(CACHE_KEY, key);
        }
    }
}