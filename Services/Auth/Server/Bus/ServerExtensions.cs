using MassTransit;
using Microsoft.Extensions.Options;
using RunSynopsis.Server.Bus.Consumers;

namespace RunSynopsis.Server.Bus
{
    public static class ServerExtensions
    {
        public static void AddBus(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddOptions()
                .AddAutoMapper(typeof(BusAutoMapperProfile));

            builder.Services
                .Configure<BusConfiguration>(builder.Configuration
                .GetSection("Server:Bus"));

            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumer<AuthSignInConsumer>();
                x.AddConsumer<AuthGetUserByIdConsumer>();
                x.AddConsumer<AuthGetUserByTokenConsumer>();
                x.AddConsumer<AuthGetTokenByValueConsumer>();
                x.AddConsumer<AuthStorePermissionConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    var configuration = context
                        .GetRequiredService<IOptions<BusConfiguration>>()
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

                    cfg.ReceiveEndpoint(configuration.Endpoint, e =>
                    {
                        e.ConfigureConsumer<AuthSignInConsumer>(context);
                        e.ConfigureConsumer<AuthGetUserByIdConsumer>(context);
                        e.ConfigureConsumer<AuthGetUserByTokenConsumer>(context);
                        e.ConfigureConsumer<AuthGetTokenByValueConsumer>(context);
                        e.ConfigureConsumer<AuthStorePermissionConsumer>(context);
                    });
                });
            });
        }
    }
}