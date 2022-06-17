using RunSynopsis.Domain.Contact;
using RunSynopsis.Domain.Contact.Entities;

namespace RunSynopsis.Server.Api
{
    public class Mutation
    {
        public async Task<bool> SubmitAsync(IContactService service, Message message)
        {
            await service.SubmitAsync(message);

            return true;
        }

        public async Task<bool> DeleteAsync(IContactService service, [ID] Guid id)
        {
            await service.DeleteAsync(id);

            return true;
        }
    }
}