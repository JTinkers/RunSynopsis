using Microsoft.Extensions.Options;
using RunSynopsis.Server.Monitoring.Configuration;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace RunSynopsis.Server.Monitoring
{
    public class ServiceHealthService : IServiceHealthService
    {
        private const uint Timeout = 1000;

        private readonly IServiceHealthCache _cache;

        private readonly ServiceHealthConfiguration _configuration;

        public ServiceHealthService(
            IServiceHealthCache cache,
            IOptions<ServiceHealthConfiguration> configuration)
        {
            _cache = cache;
            _configuration = configuration.Value;
        }

        public async Task<ServiceHealth> GetServiceHealthStatusAsync(string service)
        {
            var cached = await _cache.HasEntryAsync(service);

            if (cached)
                return await _cache.RetrieveAsync(service);

            var ping = new Ping();

            var options = new PingOptions(64, true);

            var buffer = new[] { byte.MaxValue };

            var uri = _configuration.Services
                .Single(x => x.Name == service)
                .Uri
                .ToString();

            var stopwatch = Stopwatch.StartNew();

            PingReply? reply = null;

            try
            {
                reply = await ping.SendPingAsync(uri, (int)Timeout, buffer, options);
            }
            catch (PingException) { }

            stopwatch.Stop();

            var status = new ServiceHealth
            {
                Name = service,
                IsAlive = reply?.Status == IPStatus.Success,
                ResponseTime = stopwatch.Elapsed.TotalMilliseconds,
            };

            _ = _cache.StoreAsync(service, status);

            return status;
        }

        public async Task<IEnumerable<ServiceHealth>> GetServiceHealthStatusesAsync()
        {
            var statuses = new List<ServiceHealth>();

            foreach (var service in _configuration.Services)
            {
                var status = await GetServiceHealthStatusAsync(service.Name);

                statuses.Add(status);
            }

            return statuses;
        }
    }
}