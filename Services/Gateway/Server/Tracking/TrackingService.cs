using RunSynopsis.Server.Tracking.Exceptions;

namespace RunSynopsis.Server.Tracking
{
    public class TrackingService : ITrackingService
    {
        private readonly ITrackingCache _cache;

        public TrackingService(ITrackingCache cache)
        {
            _cache = cache;
        }

        public async Task<string> CreateTrackerAsync(Dictionary<string, object> data)
        {
            var tracker = Guid.NewGuid().ToString();

            await _cache.StoreAsync(tracker, data);

            return tracker;
        }

        public async Task<Dictionary<string, object>> GetTrackerAsync(string tracker)
        {
            var hasEntry = await _cache.HasEntryAsync(tracker);

            if (!hasEntry)
                throw new TrackingException("Tracker was not found");

            return await _cache.RetrieveAsync(tracker);
        }

        public async Task<bool> TrackerExistsAsync(string tracker)
        {
            return await _cache.HasEntryAsync(tracker);
        }
    }
}