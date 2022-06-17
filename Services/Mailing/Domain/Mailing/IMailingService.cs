using RunSynopsis.Domain.Mailing.Entities;

namespace RunSynopsis.Domain.Mailing
{
    public interface IMailingService
    {
        Task SendMessageAsync(IEnumerable<Recipient> recipients, Message message);
    }
}