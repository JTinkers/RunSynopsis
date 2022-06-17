using RunSynopsis.Domain.Auth.Entities;
using RunSynopsis.Server.Api.Middleware;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(x => x.SignInAsync(default!, default!, default!))
                .Name("auth_signIn")
                .Ignore()
                .UseProjection();

            descriptor.Field(x => x.UpdateUserAsync(default!, default!, default!))
                .Name("auth_updateUser")
                .UseAuth();

            descriptor.Field(x => x.GrantAsync(default!, default!, default!, default!))
                .Name("auth_grant")
                .UseAuth(AuthPermission.ManagePermissions);

            descriptor.Field(x => x.RevokeAsync(default!, default!, default!, default!))
                .Name("auth_revoke")
                .UseAuth(AuthPermission.ManagePermissions);
        }
    }
}