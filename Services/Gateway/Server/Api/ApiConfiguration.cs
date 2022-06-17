using RunSynopsis.Server.Middleware;

namespace RunSynopsis.Server.Api
{
    public class ApiConfiguration
    {
        public AuthMiddlewareConfiguration Auth { get; set; }

        public TrackingMiddlewareConfiguration Tracking { get; set; }

        public ApiStitchingConfiguration Stitching { get; set; }
    }
}