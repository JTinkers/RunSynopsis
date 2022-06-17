using RunSynopsis.Server.Monitoring;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class ServiceHealthType : ObjectType<ServiceHealth>
    {
        protected override void Configure(IObjectTypeDescriptor<ServiceHealth> descriptor)
        {
            descriptor.Field(x => x.Name);
            descriptor.Field(x => x.IsAlive);
            descriptor.Field(x => x.ResponseTime);
        }
    }
}