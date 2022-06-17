using Newtonsoft.Json;
using RunSynopsis.Application.Storage.Ports.Configuration;
using RunSynopsis.Domain.Auth;
using RunSynopsis.Domain.Storage.Entities;
using RunSynopsis.Domain.Storage.Ports;
using StackExchange.Redis;

namespace RunSynopsis.Application.Storage.Ports
{
    internal class MediaRegistry : IMediaRegistry
    {
        private readonly IDatabase _database;

        private readonly MediaRegistryConfiguration _configuration;

        private readonly IUserContext _userContext;

        public MediaRegistry(
            IConnectionMultiplexer redis,
            MediaRegistryConfiguration configuration,
            IUserContext userContext)
        {
            _configuration = configuration;
            _userContext = userContext;
            _database = redis.GetDatabase();
        }

        public async Task<IEnumerable<Storable>> GetListAsync()
        {
            _userContext.Authorize(StoragePermission.List);

            return (await _database.HashGetAllAsync(_configuration.Key))
                .Select(entry => JsonConvert.DeserializeObject<Storable>(entry.Value!)!);
        }

        public async Task StoreAsync(Storable media)
        {
            var serialized = JsonConvert.SerializeObject(media);

            await _database.HashSetAsync(_configuration.Key, media.Hash, serialized,
                When.NotExists, CommandFlags.FireAndForget);
        }

        public async Task<Storable?> RetrieveAsync(string hash)
        {
            var serialized = await _database.HashGetAsync(_configuration.Key, hash);

            if (serialized.IsNull)
                return null;

            return JsonConvert.DeserializeObject<Storable>(serialized!);
        }

        public async Task<bool> ExistsAsync(string hash)
            => await _database.HashExistsAsync(_configuration.Key, hash);

        public async Task DeleteAsync(string hash)
            => await _database.HashDeleteAsync(_configuration.Key, hash);
    }
}