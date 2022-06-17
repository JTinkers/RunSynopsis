using RunSynopsis.Domain.Contact.Entities;

namespace RunSynopsis.Domain.Contact.Ports
{
    internal interface IContactCache
    {
        Task<IEnumerable<Message>> RetrieveAllAsync();

        Task StoreAsync(Message message);

        Task DeleteAsync(Guid id);
    }
}