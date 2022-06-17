namespace RunSynopsis.Common.Bus.Contracts
{
    public class MailingRecipient
    {
        public string Name { get; set; }

        public string Mail { get; set; }

        public MailingRecipient(string name, string mail)
        {
            Name = name;
            Mail = mail;
        }
    }
}