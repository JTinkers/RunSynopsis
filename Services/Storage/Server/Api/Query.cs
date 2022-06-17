using RunSynopsis.Domain.Storage;
using RunSynopsis.Domain.Storage.Entities;

namespace RunSynopsis.Server.Api
{
    public class Query
    {
        public async Task<IEnumerable<Storable>> GetListAsync(IMediaService service)
        {
            return await service.GetListAsync();
        }
    }
}