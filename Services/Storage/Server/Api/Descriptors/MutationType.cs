using RunSynopsis.Domain.Storage.Entities;
using RunSynopsis.Server.Api.Middleware;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(x => x.StoreAsync(default!, default!))
                .Name("storage_storeMedia")
                .UseAuth();

            descriptor.Field(x => x.DeleteAsync(default!, default!))
                .Name("storage_deleteMedia")
                .UseAuth(StoragePermission.Delete);
        }
    }
}