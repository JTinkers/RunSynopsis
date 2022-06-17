using RunSynopsis.Domain.Storage.Entities;

namespace RunSynopsis.Domain.Storage.Ports
{
    internal interface IMediaStreamRepository
    {
        Task StoreAsync(Stream stream, Storable media);

        Task<Stream> RetrieveAsync(Storable media);

        Task DeleteAsync(Storable media);
    }
}