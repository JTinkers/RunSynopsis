namespace RunSynopsis.Domain.Storage.Ports
{
    internal interface IMediaContentTypeInspector
    {
        string GetMimeType(string extension);
    }
}