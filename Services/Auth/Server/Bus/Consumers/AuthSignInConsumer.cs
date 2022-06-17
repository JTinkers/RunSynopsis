using AutoMapper;
using MassTransit;
using RunSynopsis.Common.Bus.Contracts;
using RunSynopsis.Domain.Auth;

namespace RunSynopsis.Server.Bus.Consumers
{
    public class AuthSignInConsumer : IConsumer<IAuthSignInRequest>
    {
        private readonly IAuthService _service;

        private readonly IMapper _mapper;

        public AuthSignInConsumer(IAuthService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<IAuthSignInRequest> context)
        {
            var username = context.Message.Username;
            var password = context.Message.Password;

            var token = await _service.SignInAsync(username, password);
            var authToken = _mapper.Map<AuthToken>(token);

            await context.RespondAsync<IAuthSignInResponse>
                (new AuthSignInResponse(authToken));
        }
    }
}