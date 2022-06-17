using RunSynopsis.Domain.Auth.Entities;
using RunSynopsis.Server.Api.Middleware;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(x => x.GetPermissions(default!))
                .UseProjection()
                .UseFiltering()
                .UseSorting()
                .Name("auth_getPermissions");

            descriptor.Field(x => x.GetUserByIdAsync(default!, default!))
                .Name("auth_getUserById")
                .UseProjection();

            descriptor.Field(x => x.GetUsers(default!))
                .Name("auth_getUsers")
                .UsePaging()
                .UseProjection()
                .UseFiltering()
                .UseSorting()
                .UseAuth(AuthPermission.ListUsers);

            descriptor.Field(x => x.GetMe(default!))
                .UseProjection()
                .Name("auth_whoIsMe");
        }
    }
}