namespace RunSynopsis.Server.Auth
{
    public class AuthBusConfiguration
    {
        public string Host { get; set; }

        public ushort Port { get; set; }

        public string VirtualHost { get; set; }

        public string ConnectionName { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public Uri EndpointUri { get; set; }
    }
}