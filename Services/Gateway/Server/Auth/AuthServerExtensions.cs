using MassTransit;
using MassTransit.MultiBus;
using RunSynopsis.Common.Bus.Contracts;
using RunSynopsis.Server.Middleware;

namespace RunSynopsis.Server.Auth
{
    public static class ApplicationServerExtensions
    {
        /// <summary>
        /// Register and configure services used by the Auth layer
        /// </summary>
        /// <param name="builder">WebApp builder to attach to</param>
        public static void AddAuth(this WebApplicationBuilder builder)
        {
            builder.Services.AddOptions();
            builder.Services.AddAutoMapper(typeof(AuthAutoMapperProfile));
            builder.Services.AddScoped<IUserCache, UserCache>();
            builder.Services.AddScoped<ITokenCache, TokenCache>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services
                .Configure<UserCacheConfiguration>(builder.Configuration
                .GetSection("Server:Auth:UserCache"));

            builder.Services
                .Configure<TokenCacheConfiguration>(builder.Configuration
                .GetSection("Server:Auth:TokenCache"));

            builder.Services
                .Configure<AuthBusConfiguration>(builder.Configuration
                .GetSection("Server:Auth:Bus"));

            var configuration = builder.Configuration
                .GetSection("Server:Auth:Bus")
                .Get<AuthBusConfiguration>();

            builder.Services.AddMassTransit<IAuthBus>(x =>
            {
                x.AddRequestClient<IAuthSignInRequest>(
                    configuration.Endpoint, 30000);

                x.AddRequestClient<IAuthGetUserByTokenRequest>(
                    configuration.Endpoint, 30000);

                x.AddRequestClient<IAuthGetTokenByValueRequest>(
                    configuration.Endpoint, 30000);

                x.UsingRabbitMq((_, cfg) =>
                {
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

        /// <summary>
        /// Add neccessary services used by the Auth layer
        /// </summary>
        /// <param name="app">App to attach to</param>
        public static void UseAuth(this WebApplication app)
        {
            app.UseMiddleware<AuthMiddleware>();
        }
    }
}