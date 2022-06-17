using RunSynopsis.Domain.Content.Payloads;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class UpdateTagRequestInputType : InputObjectType<UpdateTagRequest>
    {
        protected override void Configure(IInputObjectTypeDescriptor<UpdateTagRequest> descriptor)
        {
            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.Name);
            descriptor.Field(x => x.Description);
        }
    }
}