using Microsoft.Extensions.DependencyInjection;
using RunSynopsis.Application.Storage.Ports;
using RunSynopsis.Application.Storage.Ports.Configuration;
using RunSynopsis.Domain.Auth;
using RunSynopsis.Domain.Storage;
using RunSynopsis.Domain.Storage.Ports;
using StackExchange.Redis;

namespace RunSynopsis.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddStorageService(this IServiceCollection services,
            MediaRegistryConfiguration registryConfiguration,
            MediaStreamRepositoryConfiguration streamRepositoryConfiguration)
        {
            services.AddSingleton(registryConfiguration);
            services.AddSingleton(streamRepositoryConfiguration);
            services.AddSingleton<IMediaStreamRepository, MediaStreamRepository>();
            services.AddSingleton<IMediaContentTypeInspector, MediaContentTypeInspector>();
            services.AddScoped<IMediaRegistry, MediaRegistry>();
            services.AddScoped<IMediaService, MediaService>();
            services.AddScoped<IUserContext, UserContext>();

            var redisOptions = new ConfigurationOptions
            {
                AbortOnConnectFail = false,
                EndPoints = { "rsstorage-redis" }
            };

            services.AddSingleton<IConnectionMultiplexer>(
                ConnectionMultiplexer.Connect(redisOptions));
        }
    }
}