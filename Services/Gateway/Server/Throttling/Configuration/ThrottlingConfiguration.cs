namespace RunSynopsis.Server.Throttling.Configuration
{
    public class ThrottlingConfiguration
    {
        public bool Enabled { get; set; }

        /// <summary>
        /// Maximum requests that can be performed before throttling kicks in
        /// </summary>
        public int MaxRate { get; set; }

        public ThrottlingCacheConfiguration Cache { get; set; }
    }
}