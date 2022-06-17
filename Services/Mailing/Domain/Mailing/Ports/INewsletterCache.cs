namespace RunSynopsis.Domain.Mailing.Ports
{
    internal interface INewsletterCache
    {
        Task<IEnumerable<string>> RetrieveListAsync();

        Task<string?> RetrieveAsync(Guid identifier);

        Task StoreAsync(string mail);

        Task DeleteAsync(Guid identifier);
    }
}