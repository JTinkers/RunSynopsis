using Microsoft.Extensions.Options;
using RunSynopsis.Server.Throttling.Configuration;
using RunSynopsis.Server.Throttling.Exceptions;

namespace RunSynopsis.Server.Throttling
{
    public class ThrottlingService : IThrottlingService
    {
        private readonly IThrottlingCache _cache;

        private readonly IThrottlingIdentityProvider _identityProvider;

        private readonly ThrottlingConfiguration _configuration;

        public ThrottlingService(
            IThrottlingCache cache,
            IThrottlingIdentityProvider identityProvider,
            IOptions<ThrottlingConfiguration> configuration)
        {
            _cache = cache;
            _identityProvider = identityProvider;
            _configuration = configuration.Value;
        }

        public async Task<bool> CanExecuteAsync()
        {
            if (!_configuration.Enabled)
                return true;

            var identity = _identityProvider.Get();

            if (identity is null)
                throw new ThrottlingException("Identity is invalid");

            var executions = 0;

            var hasEntry = await _cache.HasEntryAsync(identity);

            if (hasEntry)
                executions = await _cache.RetrieveAsync(identity);

            if (executions >= _configuration.MaxRate)
                return false;

            return true;
        }

        public async Task RegisterExecutionAsync()
        {
            var identity = _identityProvider.Get();

            if (identity is null)
                throw new ThrottlingException("Identity is invalid");

            var hasEntry = await _cache.HasEntryAsync(identity);

            if (!hasEntry)
                await _cache.StoreAsync(identity);

            await _cache.IncrementAsync(identity);
        }
    }
}