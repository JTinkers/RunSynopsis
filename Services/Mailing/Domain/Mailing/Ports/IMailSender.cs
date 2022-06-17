using RunSynopsis.Domain.Mailing.Entities;

namespace RunSynopsis.Domain.Mailing.Ports
{
    internal interface IMailSender
    {
        Task SendAsync(IEnumerable<Recipient> recipients, Message message);
    }
}