using MassTransit;
using Microsoft.Extensions.Options;
using RunSynopsis.Common.Bus.Contracts;

namespace RunSynopsis.Server.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ISendEndpoint _endpoint;

        public AuthService(
            IAuthBus bus,
            IOptions<AuthBusConfiguration> configuration)
        {
            _endpoint = bus.GetSendEndpoint(configuration.Value.EndpointUri)
                .GetAwaiter()
                .GetResult();
        }

        public async Task StorePermissionAsync<TEnum>(TEnum permission) where TEnum : Enum
        {
            var authPermission = new AuthPermission(typeof(TEnum).Name, permission.ToString());

            var request = new AuthStorePermissionRequest(authPermission);

            await _endpoint.Send(request);
        }
    }
}