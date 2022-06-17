using AutoMapper;
using MassTransit;
using MediatR;
using RunSynopsis.Common.Bus.Contracts;
using RunSynopsis.Domain.Auth.Events;

namespace RunSynopsis.Server.Bus.Handlers
{
    public class AuthUserUpdatedHandler : INotificationHandler<AuthUserUpdated>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        private readonly IMapper _mapper;

        public AuthUserUpdatedHandler(
            IPublishEndpoint publishEndpoint, 
            IMapper mapper)
        {
            _publishEndpoint = publishEndpoint;
            _mapper = mapper;
        }

        public async Task Handle(AuthUserUpdated notification, CancellationToken cancellationToken)
        {
            var authUser = _mapper.Map<AuthUser>(notification.User);

            await _publishEndpoint.Publish(new AuthUserUpdatedNotification(authUser));
        }
    }
}