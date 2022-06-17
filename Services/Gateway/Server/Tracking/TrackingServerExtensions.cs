using RunSynopsis.Server.Middleware;

namespace RunSynopsis.Server.Tracking
{
    public static class TrackingServerExtensions
    {
        /// <summary>
        /// Register and configure services used by the tracking layer
        /// </summary>
        /// <param name="builder">WebApp builder to attach to</param>
        public static void AddTracking(this WebApplicationBuilder builder)
        {
            builder.Services.AddOptions();
            builder.Services.AddScoped<ITrackingCache, TrackingCache>();
            builder.Services.AddScoped<ITrackingService, TrackingService>();
            builder.Services.AddScoped<ITrackingContextProvider, TrackingContextProvider>();
        }

        /// <summary>
        /// Add neccessary services used by the tracking layer
        /// </summary>
        /// <param name="app">App to attach to</param>
        public static void UseTracking(this WebApplication app)
        {
            app.UseMiddleware<TrackingMiddleware>();
        }
    }
}