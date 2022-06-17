using RunSynopsis.Domain.Content.Payloads;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class UpdateCategoryRequestInputType : InputObjectType<UpdateCategoryRequest>
    {
        protected override void Configure(IInputObjectTypeDescriptor<UpdateCategoryRequest> descriptor)
        {
            descriptor.Field(x => x.Id).ID();
            descriptor.Field(x => x.Name);
            descriptor.Field(x => x.Description);
        }
    }
}