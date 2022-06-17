using RunSynopsis.Domain.Content.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class ArticleType : ObjectType<Article>
    {
        protected override void Configure(IObjectTypeDescriptor<Article> descriptor)
        {
            descriptor.Field(x => x.Id).ID();
            descriptor.Field(x => x.CategoryId).ID();
            descriptor.Field(x => x.AuthorId).ID();
            descriptor.Field(x => x.Title);
            descriptor.Field(x => x.Slug);
            descriptor.Field(x => x.Synopsis);
            descriptor.Field(x => x.HeaderSrc);
            descriptor.Field(x => x.Content);
            descriptor.Field(x => x.WrittenAt);
            descriptor.Field(x => x.UpdatedAt);
            descriptor.Field(x => x.Category);
            descriptor.Field(x => x.Author);

            descriptor.Field(x => x.Tags)
                .UseSorting();
        }
    }
}