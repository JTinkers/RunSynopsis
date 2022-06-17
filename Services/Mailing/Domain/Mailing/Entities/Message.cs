namespace RunSynopsis.Domain.Mailing.Entities
{
    public class Message
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public Message(string subject, string body)
        {
            Subject = subject;
            Body = body;
        }
    }
}