namespace RunSynopsis.Server.Bus
{
    public class BusConfiguration
    {
        public string Host { get; set; }

        public ushort Port { get; set; }

        public string VirtualHost { get; set; }

        public string ConnectionName { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public string Endpoint { get; set; }
    }
}