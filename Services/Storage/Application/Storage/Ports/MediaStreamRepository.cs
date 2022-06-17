using RunSynopsis.Application.Storage.Ports.Configuration;
using RunSynopsis.Domain.Storage.Entities;
using RunSynopsis.Domain.Storage.Ports;
using Path = System.IO.Path;

namespace RunSynopsis.Application.Storage.Ports
{
    internal class MediaStreamRepository : IMediaStreamRepository
    {
        private readonly MediaStreamRepositoryConfiguration _configuration;

        public MediaStreamRepository(MediaStreamRepositoryConfiguration configuration)
        {
            _configuration = configuration;

            var path = Path.Combine(Environment.CurrentDirectory, _configuration.RootDirectory);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public async Task StoreAsync(Stream stream, Storable media)
        {
            var path = Path.Combine(_configuration.RootDirectory, media.Subdirectory ?? string.Empty);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var file = Path.Combine(path, media.Hash + media.Extension);

            using var filestream = new FileStream(file, FileMode.CreateNew);

            await stream.CopyToAsync(filestream);

            stream.Position = 0;

            await filestream.FlushAsync();
            await filestream.DisposeAsync();
        }

        public async Task<Stream> RetrieveAsync(Storable media)
        {
            var path = Path.Combine(_configuration.RootDirectory, media.Subdirectory ?? "");
            var file = Path.Combine(path, media.Hash + media.Extension);

            using var filestream = new FileStream(file, FileMode.Open);

            var stream = new MemoryStream(new byte[filestream.Length]);

            await filestream.CopyToAsync(stream);
            await filestream.FlushAsync();
            await filestream.DisposeAsync();

            stream.Position = 0;

            return stream;
        }

        public Task DeleteAsync(Storable media)
        {
            var path = Path.Combine(_configuration.RootDirectory, media.Subdirectory ?? "");
            var file = Path.Combine(path, media.Hash + media.Extension);

            File.Delete(file);

            return Task.CompletedTask;
        }
    }
}