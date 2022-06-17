using HotChocolate.Data.Sorting;
using RunSynopsis.Domain.Storage.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class MediaSortInputType : SortInputType<Storable>
    {
        protected override void Configure(ISortInputTypeDescriptor<Storable> descriptor)
        {
            descriptor.Field(x => x.Name);
            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.Subdirectory);
            descriptor.Field(x => x.StoredAt);
        }
    }
}