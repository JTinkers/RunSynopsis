using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RunSynopsis.Server.Monitoring.Configuration;
using StackExchange.Redis;

namespace RunSynopsis.Server.Monitoring
{
    public class ServiceHealthCache : IServiceHealthCache
    {
        private const string CACHE_KEY = "monitoring:service:{0}";

        private readonly IDatabase _database;

        private readonly ServiceHealthCacheConfiguration _configuration;

        public ServiceHealthCache(
            IConnectionMultiplexer redis,
            IOptions<ServiceHealthConfiguration> configuration)
        {
            _database = redis.GetDatabase();
            _configuration = configuration.Value.Cache;
        }

        public async Task<bool> HasEntryAsync(string key)
        {
            return await _database.KeyExistsAsync(GetKey(key));
        }

        public async Task StoreAsync(string key, ServiceHealth health)
        {
            var serialized = JsonConvert.SerializeObject(health);
            var expiration = TimeSpan.FromSeconds(_configuration.Expiration);

            await _database.StringSetAsync(GetKey(key), serialized, expiration,
                When.NotExists, CommandFlags.FireAndForget);
        }

        public async Task<ServiceHealth> RetrieveAsync(string key)
        {
            var serialized = await _database.StringGetAsync(GetKey(key));
            var deserialized = JsonConvert.DeserializeObject<ServiceHealth>(serialized);

            return deserialized!;
        }

        private string GetKey(string key)
        {
            return string.Format(CACHE_KEY, key);
        }
    }
}