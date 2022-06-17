using HotChocolate.Data.Filters;
using RunSynopsis.Domain.Content.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class CategoryFilterInputType : FilterInputType<Category>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Category> descriptor)
        {
            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.Name);
        }
    }
}