namespace RunSynopsis.Server.Tracking
{
    public interface ITrackingService
    {
        Task<string> CreateTrackerAsync(Dictionary<string, object> data);

        Task<Dictionary<string, object>> GetTrackerAsync(string tracker);

        Task<bool> TrackerExistsAsync(string tracker);
    }
}