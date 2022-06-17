using Microsoft.Extensions.DependencyInjection;
using RunSynopsis.Application.Contact.Ports;
using RunSynopsis.Domain.Auth;
using RunSynopsis.Domain.Contact;
using RunSynopsis.Domain.Contact.Ports;
using RunSynopsis.Domain.Contact.Validators;
using StackExchange.Redis;

namespace RunSynopsis.Application
{
    public static class ServiceCollectionExtension
    {
        public static void AddContactService(this IServiceCollection services,
            ContactCacheConfiguration contactCacheConfiguration)
        {
            services.AddSingleton(contactCacheConfiguration);
            services.AddScoped<NewMessageValidator>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IContactCache, ContactCache>();
            services.AddScoped<IUserContext, UserContext>();

            var redisOptions = new ConfigurationOptions
            {
                AbortOnConnectFail = false,
                EndPoints = { "rscontact-redis" }
            };

            services.AddSingleton<IConnectionMultiplexer>(
                ConnectionMultiplexer.Connect(redisOptions));
        }
    }
}