using AutoMapper;
using MassTransit;
using RunSynopsis.Common.Bus.Contracts;
using RunSynopsis.Domain.Auth;

namespace RunSynopsis.Server.Bus.Consumers
{
    public class AuthGetUserByIdConsumer : IConsumer<IAuthGetUserByIdRequest>
    {
        private readonly IAuthService _service;

        private readonly IMapper _mapper;

        public AuthGetUserByIdConsumer(IAuthService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<IAuthGetUserByIdRequest> context)
        {
            var user = await _service.GetUserByIdAsync(context.Message.Id);

            if (user is null)
            {
                await context.RespondAsync<IAuthGetUserByIdResponse>
                    (new AuthGetUserByIdResponse(null));

                return;
            }

            // trigger lazy-loading
            _ = user.Permissions;

            var authUser = _mapper.Map<AuthUser>(user);

            await context.RespondAsync<IAuthGetUserByIdResponse>
                (new AuthGetUserByIdResponse(authUser));
        }
    }
}