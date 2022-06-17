using RunSynopsis.Domain.Storage.Entities;
using RunSynopsis.Server.Api.Middleware;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(x => x.GetListAsync(default!))
                .Name("storage_getMediaList")
                .UsePaging()
                .UseFiltering()
                .UseSorting()
                .UseAuth(StoragePermission.List);
        }
    }
}