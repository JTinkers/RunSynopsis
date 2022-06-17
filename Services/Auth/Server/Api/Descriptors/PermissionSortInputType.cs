using HotChocolate.Data.Sorting;
using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class PermissionSortInputType : SortInputType<Permission>
    {
        protected override void Configure(ISortInputTypeDescriptor<Permission> descriptor)
        {
            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.Type);
            descriptor.Field(x => x.Value);
        }
    }
}