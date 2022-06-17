using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace RunSynopsis.Server
{
    public static class ServerExtensions
    {
        /// <summary>
        /// Register and configure services used by the Proxy layer
        /// </summary>
        /// <param name="builder">WebApp builder to attach to</param>
        public static void AddProxy(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddOcelot(builder.Configuration
                .GetSection("Api:Proxy"));
        }

        /// <summary>
        /// Add neccessary services used by the Auth layer
        /// </summary>
        /// <param name="app">App to attach to</param>
        public static void UseProxy(this WebApplication app)
        {
            app.UseRouting();
            app.UseOcelot().Wait();
        }
    }
}