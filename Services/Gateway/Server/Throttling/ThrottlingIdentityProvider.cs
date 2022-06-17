namespace RunSynopsis.Server.Throttling
{
    public class ThrottlingIdentityProvider : IThrottlingIdentityProvider
    {
        private string _identity;

        public string Get()
        {
            return _identity;
        }

        public void Set(string identity)
        {
            _identity = identity;
        }
    }
}