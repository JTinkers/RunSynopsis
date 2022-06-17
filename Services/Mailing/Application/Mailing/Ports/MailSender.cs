using FluentEmail.Core;
using FluentEmail.Core.Models;
using RunSynopsis.Domain.Mailing.Entities;
using RunSynopsis.Domain.Mailing.Ports;

namespace RunSynopsis.Application.Mailing.Ports
{
    internal class MailSender : IMailSender
    {
        private readonly IFluentEmailFactory _factory;

        public MailSender(IFluentEmailFactory factory)
        {
            _factory = factory;
        }

        public async Task SendAsync(
            IEnumerable<Recipient> recipients,
            Message message)
        {
            var addresses = recipients.Select(x => new Address(x.Email, x.Name));

            var mail = _factory
                .Create()
                .To(addresses)
                .Subject(message.Subject)
                .Body(message.Body, true);

            await mail.SendAsync();
        }
    }
}