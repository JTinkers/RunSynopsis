using HotChocolate.Data.Filters;
using RunSynopsis.Domain.Content.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class PostFilterInputType : FilterInputType<Post>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Post> descriptor)
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