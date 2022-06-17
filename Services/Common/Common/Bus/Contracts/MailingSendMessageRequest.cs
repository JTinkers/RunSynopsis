namespace RunSynopsis.Common.Bus.Contracts
{
    public class MailingSendMessageRequest : IMailingSendMessageRequest
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public IEnumerable<MailingRecipient> Recipients { get; set; }

        public MailingSendMessageRequest(
            IEnumerable<MailingRecipient> recipients,
            string subject, string body)
        {
            Subject = subject;
            Body = body;
            Recipients = recipients;
        }
    }
}