using RunSynopsis.Domain.Auth;
using RunSynopsis.Domain.Storage.Entities;
using RunSynopsis.Domain.Storage.Exceptions;
using RunSynopsis.Domain.Storage.Ports;

namespace RunSynopsis.Domain.Storage
{
    internal class MediaService : IMediaService
    {
        private readonly IMediaRegistry _registry;

        private readonly IMediaStreamRepository _repository;

        private readonly IUserContext _userContext;

        public MediaService(
            IMediaRegistry registry,
            IMediaStreamRepository repository,
            IUserContext userContext)
        {
            _registry = registry;
            _repository = repository;
            _userContext = userContext;
        }

        public async Task<string> StoreAsync(
            Stream stream,
            string name,
            string extension,
            string? subdirectory = null)
        {
            _userContext.Authorize(StoragePermission.Store);

            var user = _userContext.GetUser();
            var media = new Storable(name, extension, subdirectory, user?.Id);

            await _repository.StoreAsync(stream, media);
            await _registry.StoreAsync(media);

            return media.Hash;
        }

        public async Task<(Stream, Storable)> RetrieveAsync(string hash)
        {
            if (!await _registry.ExistsAsync(hash))
                throw new MediaNotFoundException($"Couldn't retrieve media - [{hash}] was not found");

            var media = (await _registry.RetrieveAsync(hash))!;
            var stream = await _repository.RetrieveAsync(media);

            return (stream, media);
        }

        public async Task DeleteAsync(string hash)
        {
            _userContext.Authorize(StoragePermission.Delete);

            var exists = await _registry.ExistsAsync(hash);

            if (!exists)
                throw new MediaNotFoundException($"Couldn't delete media - [{hash}] was not found");

            var media = (await _registry.RetrieveAsync(hash))!;

            await _repository.DeleteAsync(media);
            await _registry.DeleteAsync(hash);
        }

        public async Task<IEnumerable<Storable>> GetListAsync()
        {
            return await _registry.GetListAsync();
        }
    }
}