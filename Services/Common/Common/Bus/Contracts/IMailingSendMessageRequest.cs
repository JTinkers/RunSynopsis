namespace RunSynopsis.Common.Bus.Contracts
{
    public interface IMailingSendMessageRequest
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public IEnumerable<MailingRecipient> Recipients { get; set; }
    }
}