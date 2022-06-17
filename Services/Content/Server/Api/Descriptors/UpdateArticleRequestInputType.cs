using RunSynopsis.Domain.Content.Payloads;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class UpdateArticleRequestInputType : InputObjectType<UpdateArticleRequest>
    {
        protected override void Configure(IInputObjectTypeDescriptor<UpdateArticleRequest> descriptor)
        {
            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.Title);
            descriptor.Field(x => x.Synopsis);
            descriptor.Field(x => x.Content);
            descriptor.Field(x => x.HeaderSrc);
            descriptor.Field(x => x.CategoryId);
            descriptor.Field(x => x.TagIds);
        }
    }
}