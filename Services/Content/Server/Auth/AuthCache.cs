using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RunSynopsis.Domain.Auth.Entities;
using StackExchange.Redis;

namespace RunSynopsis.Server.Auth
{
    public class AuthCache : IAuthCache
    {
        private readonly IDatabase _database;

        private readonly AuthCacheConfiguration _configuration;

        public AuthCache(
            IConnectionMultiplexer redis,
            IOptions<AuthCacheConfiguration> configuration)
        {
            _database = redis.GetDatabase();
            _configuration = configuration.Value;
        }

        public async Task<User?> GetUserByIdAsync(long id)
        {
            var serialized = await _database.HashGetAsync(_configuration.UsersPrefix, id);

            if (serialized.IsNull)
                return null;

            return JsonConvert.DeserializeObject<User>(serialized)!;
        }

        public async Task StoreUserAsync(User user)
        {
            var serialized = JsonConvert.SerializeObject(user);

            await _database.HashSetAsync(_configuration.UsersPrefix, user.Id, serialized,
                When.NotExists, CommandFlags.FireAndForget);
        }

        public async Task<bool> UserExistsAsync(long id)
            => await _database.HashExistsAsync(_configuration.UsersPrefix, id);

        public async Task DeleteUserAsync(long id)
            => await _database.HashDeleteAsync(_configuration.UsersPrefix, id);
    }
}