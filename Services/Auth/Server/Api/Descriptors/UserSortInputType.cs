using HotChocolate.Data.Sorting;
using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class UserSortInputType : SortInputType<User>
    {
        protected override void Configure(ISortInputTypeDescriptor<User> descriptor)
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