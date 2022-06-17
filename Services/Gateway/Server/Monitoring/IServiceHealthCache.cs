namespace RunSynopsis.Server.Monitoring
{
    public interface IServiceHealthCache
    {
        Task StoreAsync(string key, ServiceHealth health);

        Task<ServiceHealth> RetrieveAsync(string key);

        Task<bool> HasEntryAsync(string key);
    }
}