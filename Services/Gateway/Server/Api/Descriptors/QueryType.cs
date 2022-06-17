namespace RunSynopsis.Server.Api.Descriptors
{
    public class QueryType : ObjectTypeExtension<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(x => x.GetServiceHealthStatusesAsync(default!))
                .Name("gateway_getServiceHealthStatuses");
        }
    }
}