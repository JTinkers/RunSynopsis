using MassTransit;
using MassTransit.MultiBus;
using Microsoft.Extensions.Options;

namespace RunSynopsis.Server.Auth
{
    public static class ServerExtensions
    {
        public static void AddAuth(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddTransient<IStartupFilter, AuthStartupFilter>();

            builder.Services
                .Configure<AuthBusConfiguration>(builder.Configuration
                .GetSection("Server:Auth:Bus"));

            builder.Services.AddMassTransit<IAuthBus>(x =>
            {
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