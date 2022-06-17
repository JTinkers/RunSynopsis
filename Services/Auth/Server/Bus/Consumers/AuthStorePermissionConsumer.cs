using AutoMapper;
using MassTransit;
using RunSynopsis.Common.Bus.Contracts;
using RunSynopsis.Domain.Auth;
using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Server.Bus.Consumers
{
    public class AuthStorePermissionConsumer : IConsumer<IAuthStorePermissionRequest>
    {
        private readonly IAuthService _service;

        private readonly IMapper _mapper;

        public AuthStorePermissionConsumer(IAuthService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<IAuthStorePermissionRequest> context)
        {
            var permission = _mapper.Map<Permission>(context.Message.Permission);

            await _service.StorePermissionsAsync(permission);
        }
    }
}