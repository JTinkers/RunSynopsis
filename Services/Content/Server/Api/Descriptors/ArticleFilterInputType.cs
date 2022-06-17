using HotChocolate.Data.Filters;
using RunSynopsis.Domain.Content.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class ArticleFilterInputType : FilterInputType<Article>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Article> descriptor)
        {
            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.CategoryId);
            descriptor.Field(x => x.AuthorId);
            descriptor.Field(x => x.Title);
            descriptor.Field(x => x.WrittenAt);
            descriptor.Field(x => x.UpdatedAt);
        }
    }
}