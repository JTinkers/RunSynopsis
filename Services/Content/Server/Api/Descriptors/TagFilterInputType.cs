using HotChocolate.Data.Filters;
using RunSynopsis.Domain.Content.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class TagFilterInputType : FilterInputType<Tag>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Tag> descriptor)
        {
            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.Name);
        }
    }
}