using RunSynopsis.Domain.Content.Payloads;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class UpdatePostRequestInputType : InputObjectType<UpdatePostRequest>
    {
        protected override void Configure(IInputObjectTypeDescriptor<UpdatePostRequest> descriptor)
        {
            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.Title);
            descriptor.Field(x => x.Content);
            descriptor.Field(x => x.CategoryId);
            descriptor.Field(x => x.TagIds);
        }
    }
}