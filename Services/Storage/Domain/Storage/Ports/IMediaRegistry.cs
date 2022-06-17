using RunSynopsis.Domain.Storage.Entities;

namespace RunSynopsis.Domain.Storage.Ports
{
    internal interface IMediaRegistry
    {
        Task<IEnumerable<Storable>> GetListAsync();

        Task StoreAsync(Storable media);

        Task<Storable?> RetrieveAsync(string hash);

        Task<bool> ExistsAsync(string hash);

        Task DeleteAsync(string hash);
    }
}