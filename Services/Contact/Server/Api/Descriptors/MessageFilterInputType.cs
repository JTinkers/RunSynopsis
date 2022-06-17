using HotChocolate.Data.Filters;
using RunSynopsis.Domain.Contact.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class MessageFilterInputType : FilterInputType<Message>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Message> descriptor)
        {
            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.Title);
            descriptor.Field(x => x.Mail);
            descriptor.Field(x => x.SubmittedAt);
        }
    }
}