using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class BanType : ObjectType<Ban>
    {
        protected override void Configure(IObjectTypeDescriptor<Ban> descriptor)
        {
            descriptor.Field(x => x.Id).ID();
            descriptor.Field(x => x.JudgeId).ID();
            descriptor.Field(x => x.UserId).ID();
            descriptor.Field(x => x.Reason);
            descriptor.Field(x => x.GivenAt);
            descriptor.Field(x => x.ExpiresAt);
            descriptor.Field(x => x.IsExpired);

            descriptor.Field(x => x.Judge)
                .UseProjection();

            descriptor.Field(x => x.User)
                .UseProjection();
        }
    }
}