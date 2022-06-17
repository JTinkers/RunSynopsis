using PommaLabs.MimeTypes;
using RunSynopsis.Domain.Storage.Ports;

namespace RunSynopsis.Application.Storage.Ports
{
    internal class MediaContentTypeInspector : IMediaContentTypeInspector
    {
        public string GetMimeType(string extension)
            => MimeTypeMap.GetMimeType(extension);
    }
}