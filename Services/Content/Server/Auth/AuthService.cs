using AutoMapper;
using MassTransit;
using Microsoft.Extensions.Options;
using RunSynopsis.Common.Bus.Contracts;
using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Server.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthCache _cache;

        private readonly IRequestClient<IAuthGetUserByIdRequest> _getUserByIdRequestClient;

        private readonly ISendEndpoint _endpoint;

        private readonly IMapper _mapper;

        public AuthService(
            IAuthCache cache,
            IAuthBus bus,
            IMapper mapper,
            IRequestClient<IAuthGetUserByIdRequest> getUserByIdRequestClient,
            IOptions<AuthBusConfiguration> configuration)
        {
            _cache = cache;
            _mapper = mapper;
            _getUserByIdRequestClient = getUserByIdRequestClient;

            _endpoint = bus.GetSendEndpoint(configuration.Value.EndpointUri)
                .GetAwaiter()
                .GetResult();
        }

        public async Task<User?> GetUserByIdAsync(long id)
        {
            if (await _cache.UserExistsAsync(id))
                return await _cache.GetUserByIdAsync(id);

            var request = new AuthGetUserByIdRequest(id);

            var response = await _getUserByIdRequestClient
                .GetResponse<IAuthGetUserByIdResponse>(request);

            if (response.Message.User == null)
                return null;

            var authUser = response.Message.User;

            var user = _mapper.Map<User>(authUser);

            await _cache.StoreUserAsync(user);

            return user;
        }

        public async Task StorePermissionAsync<TEnum>(TEnum permission) where TEnum : Enum
        {
            var authPermission = new AuthPermission(typeof(TEnum).Name, permission.ToString());

            var request = new AuthStorePermissionRequest(authPermission);

            await _endpoint.Send(request);
        }
    }
}