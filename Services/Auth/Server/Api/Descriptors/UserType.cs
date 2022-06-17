using RunSynopsis.Domain.Auth.Entities;
using RunSynopsis.Server.Api.Middleware;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(x => x.Id).ID();
            descriptor.Field(x => x.Nickname);
            descriptor.Field(x => x.Bio);
            descriptor.Field(x => x.AvatarUrl);
            descriptor.Field(x => x.HomepageUrl);
            descriptor.Field(x => x.LastSeenAt);
            descriptor.Field(x => x.CreatedAt);
            descriptor.Field(x => x.IsBanned);

            descriptor.Field(x => x.Mail)
                .UseAuth(AuthPermission.ListUsers);

            descriptor.Field(x => x.IsVerified)
                .UseAuth(AuthPermission.ListUsers);

            descriptor.Field(x => x.Permissions)
                .UseAuth(AuthPermission.ListUsers);

            descriptor.Field(x => x.GivenBans)
                .UsePaging()
                .UseProjection()
                .UseFiltering()
                .UseSorting()
                .UseAuth(AuthPermission.ListUsers);

            descriptor.Field(x => x.ReceivedBans)
                .UsePaging()
                .UseProjection()
                .UseFiltering()
                .UseSorting()
                .UseAuth(AuthPermission.ListUsers);
        }
    }
}