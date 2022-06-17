using RunSynopsis.Domain.Mailing.Entities;
using RunSynopsis.Domain.Mailing.Ports;

namespace RunSynopsis.Domain.Mailing
{
    internal class MailingService : IMailingService
    {
        private readonly IMailSender _sender;

        public MailingService(IMailSender sender)
        {
            _sender = sender;
        }

        public async Task SendMessageAsync(
            IEnumerable<Recipient> recipients,
            Message message)
        {
            await _sender.SendAsync(recipients, message);
        }
    }
}