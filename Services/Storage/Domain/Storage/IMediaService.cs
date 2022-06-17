using RunSynopsis.Domain.Storage.Entities;

namespace RunSynopsis.Domain.Storage
{
    public interface IMediaService
    {
        Task<IEnumerable<Storable>> GetListAsync();

        Task<string> StoreAsync(
            Stream stream,
            string name,
            string extension,
            string? subdirectory = null
        );

        Task<(Stream, Storable)> RetrieveAsync(string hash);

        Task DeleteAsync(string hash);
    }
}