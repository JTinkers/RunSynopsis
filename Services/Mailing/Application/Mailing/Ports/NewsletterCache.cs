using Newtonsoft.Json;
using RunSynopsis.Application.Mailing.Ports.Configuration;
using RunSynopsis.Domain.Mailing.Entities;
using RunSynopsis.Domain.Mailing.Ports;
using StackExchange.Redis;

namespace RunSynopsis.Application.Mailing.Ports
{
    internal class NewsletterCache : INewsletterCache
    {
        private readonly IDatabase _database;

        private readonly NewsletterCacheConfiguration _configuration;

        public NewsletterCache(
            IConnectionMultiplexer redis,
            NewsletterCacheConfiguration configuration)
        {
            _database = redis.GetDatabase();
            _configuration = configuration;
        }

        public async Task<IEnumerable<string>> RetrieveListAsync()
        {
            var mails = (await _database.HashGetAllAsync(_configuration.Key))
                .Select(x => JsonConvert.DeserializeObject<Subscriber>(x.Value!))
                .Select(x => x.Mail);

            return mails;
        }

        public async Task<string?> RetrieveAsync(Guid identifier)
        {
            var serialized = await _database.HashGetAsync(_configuration.Key, identifier.ToString());

            if (serialized.IsNull)
                return null;

            return JsonConvert.DeserializeObject<Subscriber>(serialized!).Mail;
        }

        public async Task StoreAsync(string mail)
        {
            var subscriber = new Subscriber(mail);
            var serialized = JsonConvert.SerializeObject(subscriber);

            await _database.HashSetAsync(
                _configuration.Key,
                subscriber.Identifier.ToString(),
                serialized,
                When.NotExists,
                CommandFlags.FireAndForget);
        }

        public async Task DeleteAsync(Guid identifier)
        {
            await _database.HashDeleteAsync(_configuration.Key, identifier.ToString());
        }
    }
}