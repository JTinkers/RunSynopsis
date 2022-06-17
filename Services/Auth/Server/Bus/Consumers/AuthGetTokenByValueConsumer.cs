using AutoMapper;
using MassTransit;
using RunSynopsis.Common.Bus.Contracts;
using RunSynopsis.Domain.Auth.Ports;

namespace RunSynopsis.Server.Bus.Consumers
{
    public class AuthGetTokenByValueConsumer : IConsumer<IAuthGetTokenByValueRequest>
    {
        private readonly ITokenizer _tokenizer;

        private readonly IMapper _mapper;

        public AuthGetTokenByValueConsumer(ITokenizer tokenizer, IMapper mapper)
        {
            _tokenizer = tokenizer;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<IAuthGetTokenByValueRequest> context)
        {
            var token = await _tokenizer.RetrieveAsync(context.Message.Value);

            if (token is null)
            {
                await context.RespondAsync<IAuthGetTokenByValueResponse>
                    (new AuthGetTokenByValueResponse(null));

                return;
            }

            var authToken = _mapper.Map<AuthToken>(token);

            await context.RespondAsync<IAuthGetTokenByValueResponse>
                (new AuthGetTokenByValueResponse(authToken));
        }
    }
}