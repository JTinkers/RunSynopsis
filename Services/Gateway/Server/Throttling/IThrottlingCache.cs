namespace RunSynopsis.Server.Throttling
{
    public interface IThrottlingCache
    {
        Task<bool> HasEntryAsync(string key);

        Task<int> RetrieveAsync(string key);

        Task IncrementAsync(string key);

        Task StoreAsync(string key);
    }
}