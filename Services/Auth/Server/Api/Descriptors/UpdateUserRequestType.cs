using RunSynopsis.Domain.Auth.Payloads;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class UpdateUserRequestType : InputObjectType<UpdateUserRequest>
    {
        protected override void Configure(IInputObjectTypeDescriptor<UpdateUserRequest> descriptor)
        {
            descriptor.Field(x => x.AvatarUrl);
            descriptor.Field(x => x.HomepageUrl);
            descriptor.Field(x => x.Bio);
            descriptor.Field(x => x.Password);
        }
    }
}