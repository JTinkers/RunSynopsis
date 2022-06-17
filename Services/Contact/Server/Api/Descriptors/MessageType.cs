using RunSynopsis.Domain.Contact.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class MessageType : ObjectType<Message>
    {
        protected override void Configure(IObjectTypeDescriptor<Message> descriptor)
        {
            descriptor.Field(x => x.Id).ID();
            descriptor.Field(x => x.Title);
            descriptor.Field(x => x.Body);
            descriptor.Field(x => x.Mail);
            descriptor.Field(x => x.SubmittedAt);
        }
    }
}