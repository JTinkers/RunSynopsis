using RunSynopsis.Domain.Content.Payloads;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class CreateArticleRequestInputType : InputObjectType<CreateArticleRequest>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CreateArticleRequest> descriptor)
        {
            descriptor.Field(x => x.Title);
            descriptor.Field(x => x.Synopsis);
            descriptor.Field(x => x.Content);
            descriptor.Field(x => x.HeaderSrc);
            descriptor.Field(x => x.CategoryId);
            descriptor.Field(x => x.TagIds);
        }
    }
}