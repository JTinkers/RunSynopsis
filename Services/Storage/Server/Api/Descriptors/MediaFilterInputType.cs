using HotChocolate.Data.Filters;
using RunSynopsis.Domain.Storage.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class MediaFilterInputType : FilterInputType<Storable>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Storable> descriptor)
        {
            descriptor.Field(x => x.Name);
            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.Subdirectory);
            descriptor.Field(x => x.StoredAt);
        }
    }
}