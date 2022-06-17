using HotChocolate.Data.Filters;
using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class UserFilterInputType : FilterInputType<User>
    {
        protected override void Configure(IFilterInputTypeDescriptor<User> descriptor)
        {
            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.Nickname);
            descriptor.Field(x => x.IsBanned);
            descriptor.Field(x => x.IsVerified);
            descriptor.Field(x => x.LastSeenAt);
            descriptor.Field(x => x.CreatedAt);
        }
    }
}