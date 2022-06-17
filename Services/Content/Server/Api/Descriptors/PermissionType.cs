using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class PermissionType : ObjectType<Permission>
    {
        protected override void Configure(IObjectTypeDescriptor<Permission> descriptor)
        {
            descriptor.Field(x => x.Type);
            descriptor.Field(x => x.Value);
        }
    }
}