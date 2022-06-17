using RunSynopsis.Domain.Content.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Field(x => x.Id).ID();
            descriptor.Field(x => x.Nickname);
            descriptor.Field(x => x.AvatarUrl);
            descriptor.Field(x => x.HomepageUrl);
            descriptor.Field(x => x.Bio);
        }
    }
}