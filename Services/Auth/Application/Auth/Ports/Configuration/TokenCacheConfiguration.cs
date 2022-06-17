namespace RunSynopsis.Application.Auth.Ports.Configuration
{
    public class TokenCacheConfiguration
    {
        public string Key { get; set; }

        public TokenCacheRedisConfiguration Redis { get; set; }
    }
}