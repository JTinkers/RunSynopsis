namespace RunSynopsis.Application.Mailing.Ports.Configuration
{
    public class MailSenderConfiguration
    {
        public string From { get; set; }

        public string FromAddress { get; set; }

        public string Host { get; set; }

        public ushort Port { get; set; }
    }
}