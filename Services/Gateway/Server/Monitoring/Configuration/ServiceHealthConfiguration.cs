namespace RunSynopsis.Server.Monitoring.Configuration
{
    public class ServiceHealthConfiguration
    {
        public IEnumerable<ServiceHealthServiceConfiguration> Services { get; set; }

        public ServiceHealthCacheConfiguration Cache { get; set; }
    }
}