namespace RunSynopsis.Domain.Contact.Entities
{
    public class Message
    {
        public Guid Id { get; }

        public string Title { get; set; }

        public string Mail { get; set; }

        public string Body { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        public Message()
        {
            Id = Guid.NewGuid();
        }

        public Message(string title, string mail, string body) : base()
        {       
            Title = title;
            Mail = mail;
            Body = body;
        }
    }
}