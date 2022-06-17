namespace RunSynopsis.Server.Monitoring
{
    public class ServiceHealth
    {
        public string Name { get; set; }

        public bool IsAlive { get; set; }

        public double? ResponseTime { get; set; }
    }
}