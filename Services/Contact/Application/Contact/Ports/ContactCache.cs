using Newtonsoft.Json;
using RunSynopsis.Domain.Contact.Entities;
using RunSynopsis.Domain.Contact.Ports;
using StackExchange.Redis;

namespace RunSynopsis.Application.Contact.Ports
{
    internal class ContactCache : IContactCache
    {
        private readonly IDatabase _database;

        private readonly ContactCacheConfiguration _configuration;

        public ContactCache(
            IConnectionMultiplexer redis,
            ContactCacheConfiguration configuration)
        {
            _database = redis.GetDatabase();
            _configuration = configuration;
        }

        public async Task<IEnumerable<Message>> RetrieveAllAsync()
        {
            return (await _database.HashGetAllAsync(_configuration.Key))
                .Select(entry => JsonConvert.DeserializeObject<Message>(entry.Value));
        }

        public async Task StoreAsync(Message message)
        {
            var serialized = JsonConvert.SerializeObject(message);

            await _database.HashSetAsync(
                _configuration.Key,
                message.Id.ToString(),
                serialized,
                When.NotExists,
                CommandFlags.FireAndForget);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _database.HashDeleteAsync(_configuration.Key, id.ToString());
        }
    }
}