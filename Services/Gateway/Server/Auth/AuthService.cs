using AutoMapper;
using MassTransit;
using RunSynopsis.Common.Bus.Contracts;
using RunSynopsis.Server.Auth.Entities;

namespace RunSynopsis.Server.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserCache _userCache;

        private readonly ITokenCache _tokenCache;

        private readonly IMapper _mapper;

        private readonly IRequestClient<IAuthSignInRequest> _signInRequestClient;

        private readonly IRequestClient<IAuthGetTokenByValueRequest> _getTokenByValueRequestClient;

        private readonly IRequestClient<IAuthGetUserByTokenRequest> _getUserByTokenRequestClient;

        public AuthService(
            IUserCache userCache,
            ITokenCache tokenCache,
            IMapper mapper,
            IRequestClient<IAuthSignInRequest> signInRequestClient,
            IRequestClient<IAuthGetTokenByValueRequest> getTokenByValueRequestClient,
            IRequestClient<IAuthGetUserByTokenRequest> getUserByTokenRequestClient)
        {
            _userCache = userCache;
            _tokenCache = tokenCache;
            _mapper = mapper;
            _signInRequestClient = signInRequestClient;
            _getTokenByValueRequestClient = getTokenByValueRequestClient;
            _getUserByTokenRequestClient = getUserByTokenRequestClient;
        }

        public async Task<Token?> SignInAsync(string username, string password)
        {
            var request = new AuthSignInRequest(username, password);

            var response = await _signInRequestClient
                .GetResponse<IAuthSignInResponse>(request);

            if (response.Message.Token is null)
                return null;

            return _mapper.Map<Token>(response.Message.Token);
        }

        public async Task<User?> GetUserByTokenAsync(TokenType type, string value)
        {
            var token = await GetTokenByValueAsync(value);

            if (token is null)
                return null;

            var authTokenType = _mapper.Map<AuthTokenType>(token.Type);

            var userRequest = new AuthGetUserByTokenRequest(authTokenType, value);

            var userResponse = await _getUserByTokenRequestClient
                .GetResponse<IAuthGetUserByTokenResponse>(userRequest);

            if (userResponse.Message.User is null)
                return null;

            var user = _mapper.Map<User>(userResponse.Message.User);

            await _userCache.StoreAsync(user);

            return user;
        }

        public async Task<Token?> GetTokenByValueAsync(string value)
        {
            var hasEntry = await _tokenCache.HasEntryAsync(value);

            if (hasEntry)
                return await _tokenCache.RetrieveAsync(value);

            var tokenRequest = new AuthGetTokenByValueRequest(value);

            var tokenResponse = await _getTokenByValueRequestClient
                .GetResponse<IAuthGetTokenByValueResponse>(tokenRequest);

            if (tokenResponse.Message.Token is null)
                return null;

            var token = _mapper.Map<Token>(tokenResponse.Message.Token);

            await _tokenCache.StoreAsync(token);

            return token;
        }
    }
}