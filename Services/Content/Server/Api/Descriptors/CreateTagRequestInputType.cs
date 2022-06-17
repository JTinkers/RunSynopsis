using RunSynopsis.Domain.Content.Payloads;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class CreateTagRequestInputType : InputObjectType<CreateTagRequest>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CreateTagRequest> descriptor)
        {
            descriptor.Field(x => x.Name);
            descriptor.Field(x => x.Description);
        }
    }
}