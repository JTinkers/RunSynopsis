using RunSynopsis.Domain.Content.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class TagType : ObjectType<Tag>
    {
        protected override void Configure(IObjectTypeDescriptor<Tag> descriptor)
        {
            descriptor.Field(x => x.Id).ID();
            descriptor.Field(x => x.Name);
            descriptor.Field(x => x.Description);
        }
    }
}