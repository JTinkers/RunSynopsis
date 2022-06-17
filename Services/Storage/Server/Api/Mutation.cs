using RunSynopsis.Domain.Storage;
using Path = System.IO.Path;

namespace RunSynopsis.Server.Api
{
    public class Mutation
    {
        public async Task<string> StoreAsync(IMediaService service, IFile file)
        {
            using var stream = file.OpenReadStream();

            var name = Path.GetFileNameWithoutExtension(file.Name);
            var ext = Path.GetExtension(file.Name);

            return await service.StoreAsync(stream, name, ext);
        }

        public async Task<bool> DeleteAsync(IMediaService service, string hash)
        {
            await service.DeleteAsync(hash);

            return true;
        }
    }
}