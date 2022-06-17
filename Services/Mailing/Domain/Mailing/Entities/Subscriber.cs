namespace RunSynopsis.Domain.Mailing.Entities
{
    public class Subscriber
    {
        public Guid Identifier { get; set; } = Guid.NewGuid();

        public string Mail { get; set; }

        public Subscriber(string mail)
        {
            Mail = mail;
        }
    }
}