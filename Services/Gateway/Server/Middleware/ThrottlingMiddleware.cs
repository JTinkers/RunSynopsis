using RunSynopsis.Server.Throttling;
using RunSynopsis.Server.Throttling.Exceptions;
using RunSynopsis.Server.Tracking;

namespace RunSynopsis.Server.Middleware
{
    /// <summary>
    /// Middleware executing IThrottlingService functionality
    /// </summary>
    public class ThrottlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ThrottlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Performs rate limit check on the current http request
        /// </summary>
        public async Task InvokeAsync(
            HttpContext context,
            IThrottlingIdentityProvider identityProvider,
            IThrottlingService throttlingService,
            ITrackingContextProvider trackingContextProvider)
        {
            var trackingContext = trackingContextProvider.Get();

            identityProvider.Set(trackingContext);

            var canExecute = await throttlingService.CanExecuteAsync();

            if (!canExecute)
                throw new ThrottlingException("API rate limit exceeded. Connection throttling enabled.");

            await throttlingService.RegisterExecutionAsync();

            await _next.Invoke(context);
        }
    }
}