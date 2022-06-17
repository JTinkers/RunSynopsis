using RunSynopsis.Domain.Contact.Entities;
using RunSynopsis.Server.Api.Middleware;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(x => x.FetchAsync(default!))
                .Name("contact_fetch")
                .UsePaging()
                .UseProjection()
                .UseFiltering()
                .UseSorting()
                .UseAuth(ContactPermission.View);
        }
    }
}