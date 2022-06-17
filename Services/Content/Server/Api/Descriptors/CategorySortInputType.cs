using HotChocolate.Data.Sorting;
using RunSynopsis.Domain.Content.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class CategorySortInputType : SortInputType<Category>
    {
        protected override void Configure(ISortInputTypeDescriptor<Category> descriptor)
        {
            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.Name);
        }
    }
}