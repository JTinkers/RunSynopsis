using RunSynopsis.Domain.Storage.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class MediaType : ObjectType<Storable>
    {
        protected override void Configure(IObjectTypeDescriptor<Storable> descriptor)
        {
            descriptor.Field(x => x.Hash);
            descriptor.Field(x => x.Name);
            descriptor.Field(x => x.Extension);
            descriptor.Field(x => x.Subdirectory);
            descriptor.Field(x => x.StoredAt);
        }
    }
}