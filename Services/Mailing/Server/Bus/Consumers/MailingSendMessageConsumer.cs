using AutoMapper;
using MassTransit;
using RunSynopsis.Common.Bus.Contracts;
using RunSynopsis.Domain.Mailing;
using RunSynopsis.Domain.Mailing.Entities;

namespace RunSynopsis.Server.Bus.Consumers
{
    public class MailingSendMessageConsumer : IConsumer<IMailingSendMessageRequest>
    {
        private readonly IMailingService _service;

        private readonly IMapper _mapper;

        public MailingSendMessageConsumer(
            IMailingService service,
            IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<IMailingSendMessageRequest> context)
        {
            var message = new Message(context.Message.Subject, context.Message.Body);

            var recipients = _mapper.Map<IEnumerable<Recipient>>(context.Message.Recipients);

            await _service.SendMessageAsync(recipients, message);
        }
    }
}