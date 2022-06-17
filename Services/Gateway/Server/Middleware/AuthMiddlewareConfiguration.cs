namespace RunSynopsis.Server.Middleware
{
    public class AuthMiddlewareConfiguration
    {
        public string TokenCookieName { get; set; }

        public long TokenTimespan { get; set; }
    }
}