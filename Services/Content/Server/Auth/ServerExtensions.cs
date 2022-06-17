using MassTransit;
using MassTransit.MultiBus;
using Microsoft.Extensions.Options;
using RunSynopsis.Common.Bus.Contracts;
using StackExchange.Redis;

namespace RunSynopsis.Server.Auth
{
    public static class ServerExtensions
    {
        public static void AddAuth(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddOptions()
                .AddAutoMapper(typeof(AuthAutoMapperProfile))
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<IAuthCache, AuthCache>()
                .AddTransient<IStartupFilter, AuthStartupFilter>();

            builder.Services.Configure<AuthCacheConfiguration>(builder.Configuration
                .GetSection("Server:Auth:Cache"));

            var redisOptions = new ConfigurationOptions
            {
                AbortOnConnectFail = false,
                EndPoints = { "rscontent-redis" }
            };

            builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer
                .Connect(redisOptions));

            builder.Services
                .Configure<AuthBusConfiguration>(builder.Configuration
                .GetSection("Server:Auth:Bus"));

            var configuration = builder.Configuration
                .GetSection("Server:Auth:Bus")
                .Get<AuthBusConfiguration>();

            builder.Services.AddMassTransit<IAuthBus>(x =>
            {
                x.AddRequestClient<IAuthGetUserByIdRequest>(
                    configuration.EndpointUri, 30000);

                x.UsingRabbitMq((context, cfg) =>
                {
                    var configuration = context
                        .GetRequiredService<IOptions<AuthBusConfiguration>>()
                        .Value;

                    cfg.Host(
                        configuration.Host,
                        configuration.Port,
                        configuration.VirtualHost,
                        configuration.ConnectionName,
                        config =>
                        {
                            config.Username(configuration.User);
                            config.Password(configuration.Password);
                        });
                });
            });
        }
    }
}