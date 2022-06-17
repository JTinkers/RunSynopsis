using RunSynopsis.Domain.Contact.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class MessageInputType : InputObjectType<Message>
    {
        protected override void Configure(IInputObjectTypeDescriptor<Message> descriptor)
        {
            descriptor.Field(x => x.Title);
            descriptor.Field(x => x.Body);
            descriptor.Field(x => x.Mail);
        }
    }
}