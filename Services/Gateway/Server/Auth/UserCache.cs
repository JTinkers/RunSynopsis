using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RunSynopsis.Server.Auth.Entities;
using StackExchange.Redis;

namespace RunSynopsis.Server.Auth
{
    public class UserCache : IUserCache
    {
        private readonly IDatabase _database;

        private readonly UserCacheConfiguration _configuration;

        public UserCache(
            IConnectionMultiplexer redis,
            IOptions<UserCacheConfiguration> configuration)
        {
            _database = redis.GetDatabase();
            _configuration = configuration.Value;
        }

        public async Task<bool> HasEntryAsync(string key)
        {
            key = GetKey(key);

            return await _database.KeyExistsAsync(key);
        }

        public async Task<User> RetrieveAsync(string key)
        {
            key = GetKey(key);

            var serialized = await _database.StringGetAsync(key);
            var deserialized = JsonConvert.DeserializeObject<User>(serialized);

            return deserialized!;
        }

        public async Task StoreAsync(User user)
        {
            var key = GetKey(user.Id.ToString());
            var expiration = GetExpiration();

            var serialized = JsonConvert.SerializeObject(user);

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