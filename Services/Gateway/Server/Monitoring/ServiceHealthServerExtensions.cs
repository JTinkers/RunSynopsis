using RunSynopsis.Server.Monitoring.Configuration;

namespace RunSynopsis.Server.Monitoring
{
    public static class ServiceHealthServerExtensions
    {
        public static void AddServiceHealth(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IServiceHealthCache, ServiceHealthCache>();
            builder.Services.AddSingleton<IServiceHealthService, ServiceHealthService>();

            builder.Services
                .Configure<ServiceHealthConfiguration>(builder.Configuration
                .GetSection("Server:Monitoring"));
        }
    }
}