using HotChocolate.Data.Sorting;
using RunSynopsis.Domain.Contact.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class MessageSortInputType : SortInputType<Message>
    {
        protected override void Configure(ISortInputTypeDescriptor<Message> descriptor)
        {
            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.Title);
            descriptor.Field(x => x.Body);
            descriptor.Field(x => x.Mail);
            descriptor.Field(x => x.SubmittedAt);
        }
    }
}