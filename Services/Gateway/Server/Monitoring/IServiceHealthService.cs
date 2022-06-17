namespace RunSynopsis.Server.Monitoring
{
    public interface IServiceHealthService
    {
        Task<ServiceHealth> GetServiceHealthStatusAsync(string service);

        Task<IEnumerable<ServiceHealth>> GetServiceHealthStatusesAsync();
    }
}