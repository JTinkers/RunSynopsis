using Newtonsoft.Json;
using StackExchange.Redis;

namespace RunSynopsis.Server.Tracking
{
    public class TrackingCache : ITrackingCache
    {
        private const string CACHE_KEY = "tracking";

        private readonly IDatabase _database;

        public TrackingCache(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<bool> HasEntryAsync(string key)
        {
            return await _database.HashExistsAsync(CACHE_KEY, key);
        }

        public async Task<Dictionary<string, object>> RetrieveAsync(string key)
        {
            var serialized = await _database.HashGetAsync(CACHE_KEY, key);

            return JsonConvert.DeserializeObject<Dictionary<string, object>>(serialized)!;
        }

        public async Task StoreAsync(string key, Dictionary<string, object> data)
        {
            var serialized = JsonConvert.SerializeObject(data);

            await _database.HashSetAsync(
                CACHE_KEY,
                key,
                serialized,
                When.NotExists,
                CommandFlags.FireAndForget);
        }
    }
}