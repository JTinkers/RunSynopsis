using RunSynopsis.Domain.Contact.Entities;

namespace RunSynopsis.Domain.Contact
{
    public interface IContactService
    {
        Task<IEnumerable<Message>> FetchAsync();

        Task SubmitAsync(Message message);

        Task DeleteAsync(Guid id);
    }
}