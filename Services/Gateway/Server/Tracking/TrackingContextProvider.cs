namespace RunSynopsis.Server.Tracking
{
    public class TrackingContextProvider : ITrackingContextProvider
    {
        private string _tracker;

        public string Get()
        {
            return _tracker;
        }

        public void Set(string tracker)
        {
            _tracker = tracker;
        }
    }
}