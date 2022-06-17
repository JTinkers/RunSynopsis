using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RunSynopsis.Application.Auth.Ports;
using RunSynopsis.Application.Auth.Ports.Configuration;
using RunSynopsis.Domain.Auth;
using RunSynopsis.Domain.Auth.Database;
using RunSynopsis.Domain.Auth.Ports;
using RunSynopsis.Domain.Auth.Validators;
using StackExchange.Redis;
using System.Reflection;

namespace RunSynopsis.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAuthService(this IServiceCollection services,
            TokenizerConfiguration tokenizerConfiguration,
            AuthDbContextConfig authDbContextConfig)
        {
            services
                .AddMediatR(typeof(ServiceCollectionExtensions))
                .AddSingleton(tokenizerConfiguration)
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<IUserContext, UserContext>()
                .AddSingleton<IHasher, Hasher>()
                .AddSingleton<ITokenizer, Tokenizer>()
                .AddSingleton<ITokenCache, TokenCache>()
                .AddSingleton<NewUserValidator>();

            services.AddSingleton<IConnectionMultiplexer>(provider =>
            {
                var options = tokenizerConfiguration
                    .Cache
                    .Redis
                    .GetConfigurationOptions();

                return ConnectionMultiplexer.Connect(options);
            });

            services.AddPooledDbContextFactory<AuthDbContext>((_, optionsBuilder) =>
            {
                optionsBuilder.UseLazyLoadingProxies();

                optionsBuilder.UseNpgsql(authDbContextConfig.ConnectionString, config =>
                {
                    config.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                });
            });
        }
    }
}