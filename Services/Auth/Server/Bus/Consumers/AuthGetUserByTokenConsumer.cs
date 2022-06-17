using AutoMapper;
using MassTransit;
using RunSynopsis.Common.Bus.Contracts;
using RunSynopsis.Domain.Auth;
using RunSynopsis.Domain.Auth.Ports;

namespace RunSynopsis.Server.Bus.Consumers
{
    public class AuthGetUserByTokenConsumer : IConsumer<IAuthGetUserByTokenRequest>
    {
        private readonly ITokenizer _tokenizer;

        private readonly IAuthService _service;

        private readonly IMapper _mapper;

        public AuthGetUserByTokenConsumer(
            ITokenizer tokenizer,
            IAuthService service,
            IMapper mapper)
        {
            _tokenizer = tokenizer;
            _service = service;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<IAuthGetUserByTokenRequest> context)
        {
            var token = (await _tokenizer.RetrieveAsync(context.Message.Value))!;

            var user = await _service.GetUserByIdAsync(token.UserId);

            if (user is null)
            {
                await context.RespondAsync<IAuthGetUserByTokenResponse>
                    (new AuthGetUserByTokenResponse(null));

                return;
            }

            // trigger lazy-loading
            _ = user.Permissions;

            var authUser = _mapper.Map<AuthUser>(user);

            await context.RespondAsync<IAuthGetUserByTokenResponse>
                (new AuthGetUserByTokenResponse(authUser));
        }
    }
}