using RunSynopsis.Server.Middleware;
using RunSynopsis.Server.Throttling.Configuration;

namespace RunSynopsis.Server.Throttling
{
    public static class ThrottlingServerExtensions
    {
        /// <summary>
        /// Register and configure services used by the Throttling layer
        /// </summary>
        /// <param name="builder">WebApp builder to attach to</param>
        public static void AddThrottling(this WebApplicationBuilder builder)
        {
            builder.Services.AddOptions();
            builder.Services.AddScoped<IThrottlingCache, ThrottlingCache>();
            builder.Services.AddScoped<IThrottlingService, ThrottlingService>();
            builder.Services.AddScoped<IThrottlingIdentityProvider, ThrottlingIdentityProvider>();

            builder.Services
                .Configure<ThrottlingConfiguration>(builder.Configuration
                .GetSection("Server:Throttling"));
        }

        /// <summary>
        /// Add neccessary services used by the Throttling layer
        /// </summary>
        /// <param name="app">App to attach to</param>
        public static void UseThrottling(this WebApplication app)
        {
            app.UseMiddleware<ThrottlingMiddleware>();
        }
    }
}