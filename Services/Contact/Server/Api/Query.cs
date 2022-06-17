using RunSynopsis.Domain.Contact;
using RunSynopsis.Domain.Contact.Entities;

namespace RunSynopsis.Server.Api
{
    public class Query
    {
        public async Task<IEnumerable<Message>> FetchAsync(IContactService service)
        {
            return await service.FetchAsync();
        }
    }
}