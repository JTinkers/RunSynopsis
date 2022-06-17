using RunSynopsis.Server.Monitoring;

namespace RunSynopsis.Server.Api
{
    public class Query
    {
        public async Task<IEnumerable<ServiceHealth>> GetServiceHealthStatusesAsync(IServiceHealthService service)
        {
            return await service.GetServiceHealthStatusesAsync();
        }
    }
}