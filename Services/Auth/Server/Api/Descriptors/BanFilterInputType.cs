using HotChocolate.Data.Filters;
using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class BanFilterInputType : FilterInputType<Ban>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Ban> descriptor)
        {
            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.JudgeId);
            descriptor.Field(x => x.UserId);
            descriptor.Field(x => x.Reason);
            descriptor.Field(x => x.GivenAt);
            descriptor.Field(x => x.ExpiresAt);
            descriptor.Field(x => x.IsExpired);
        }
    }
}