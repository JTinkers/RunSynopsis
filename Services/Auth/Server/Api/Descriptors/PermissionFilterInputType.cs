using HotChocolate.Data.Filters;
using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class PermissionFilterInputType : FilterInputType<Permission>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Permission> descriptor)
        {
            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.Type);
            descriptor.Field(x => x.Value);
        }
    }
}