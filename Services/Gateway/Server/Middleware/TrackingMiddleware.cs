using Microsoft.Extensions.Options;
using RunSynopsis.Server.Api;
using RunSynopsis.Server.Tracking;

namespace RunSynopsis.Server.Middleware
{
    /// <summary>
    /// Middleware executing ITrackingService functionality
    /// </summary>
    public class TrackingMiddleware
    {
        private readonly RequestDelegate _next;

        public TrackingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Attach tracker to the first request
        /// </summary>
        public async Task InvokeAsync(
            HttpContext context,
            ITrackingService service,
            ITrackingContextProvider contextProvider,
            IOptions<ApiConfiguration> configuration)
        {
            var requestCookies = context.Request.Cookies;
            var responseCookies = context.Response.Cookies;

            var cookieName = configuration.Value
                .Tracking
                .TrackerCookieName;

            if (requestCookies.ContainsKey(cookieName))
            {
                var cookie = requestCookies[cookieName];
                var trackerExists = await service.TrackerExistsAsync(cookie!);

                if (cookie is not null && trackerExists)
                {
                    contextProvider.Set(cookie!);

                    await _next.Invoke(context);

                    return;
                }
            }

            // TODO: Fix race condition, where it creates two tokens at once
            var tracker = await service
                .CreateTrackerAsync(new Dictionary<string, object>());

            responseCookies.Append(
                cookieName,
                tracker,
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None, // TODO: fix this with reverse proxy
                    MaxAge = TimeSpan.MaxValue,
                    IsEssential = true,
                });

            contextProvider.Set(tracker);

            await _next.Invoke(context);
        }
    }
}