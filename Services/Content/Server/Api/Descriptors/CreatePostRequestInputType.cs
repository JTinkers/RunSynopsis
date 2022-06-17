using RunSynopsis.Domain.Content.Payloads;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class CreatePostRequestInputType : InputObjectType<CreatePostRequest>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CreatePostRequest> descriptor)
        {
            descriptor.Field(x => x.Title);
            descriptor.Field(x => x.Content);
            descriptor.Field(x => x.CategoryId);
            descriptor.Field(x => x.TagIds);
        }
    }
}