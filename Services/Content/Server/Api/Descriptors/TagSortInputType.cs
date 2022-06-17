using HotChocolate.Data.Sorting;
using RunSynopsis.Domain.Content.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class TagSortInputType : SortInputType<Tag>
    {
        protected override void Configure(ISortInputTypeDescriptor<Tag> descriptor)
        {
            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.Name);
        }
    }
}