using MassTransit;
using RunSynopsis.Common.Bus.Contracts;

namespace RunSynopsis.Server.Bus.Consumers
{
    public class AuthUserUpdatedConsumer : IConsumer<IAuthUserUpdatedNotification>
    {
        public async Task Consume(ConsumeContext<IAuthUserUpdatedNotification> context)
        {
            var user = context.Message.User;

            // invalidate tokens
        }
    }
}