using RunSynopsis.Domain.Content.Payloads;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class CreateCategoryRequestInputType : InputObjectType<CreateCategoryRequest>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CreateCategoryRequest> descriptor)
        {
            descriptor.Field(x => x.Name);
            descriptor.Field(x => x.Description);
        }
    }
}