namespace RunSynopsis.Server.Tracking
{
    public interface ITrackingCache
    {
        Task<bool> HasEntryAsync(string key);

        Task<Dictionary<string, object>> RetrieveAsync(string key);

        Task StoreAsync(string key, Dictionary<string, object> data);
    }
}