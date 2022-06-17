using StackExchange.Redis;

namespace RunSynopsis.Application.Auth.Ports.Configuration
{
    public class TokenCacheRedisConfiguration
    {
        public bool AbortOnConnectFail { get; set; }

        public IEnumerable<string> EndPoints { get; set; }

        public ConfigurationOptions GetConfigurationOptions()
        {
            var options = new ConfigurationOptions
            {
                AbortOnConnectFail = AbortOnConnectFail,
            };

            foreach (var endpoint in EndPoints)
                options.EndPoints.Add(endpoint);

            return options;
        }
    }
}