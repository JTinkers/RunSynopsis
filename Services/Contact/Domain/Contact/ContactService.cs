using RunSynopsis.Domain.Auth;
using RunSynopsis.Domain.Contact.Entities;
using RunSynopsis.Domain.Contact.Exceptions;
using RunSynopsis.Domain.Contact.Ports;
using RunSynopsis.Domain.Contact.Validators;

namespace RunSynopsis.Domain.Contact
{
    internal class ContactService : IContactService
    {
        private readonly IContactCache _cache;

        private readonly IUserContext _userContext;

        private readonly NewMessageValidator _newMessageValidator;

        public ContactService(
            IContactCache cache,
            IUserContext userContext,
            NewMessageValidator newMessageValidator)
        {
            _cache = cache;
            _userContext = userContext;
            _newMessageValidator = newMessageValidator;
        }

        public async Task<IEnumerable<Message>> FetchAsync()
        {
            _userContext.Authorize(ContactPermission.View);

            return await _cache.RetrieveAllAsync();
        }

        public async Task SubmitAsync(Message message)
        {
            var validation = _newMessageValidator.Validate(message);

            if (!validation.IsValid)
                throw new MessageValidationException(validation.Errors[0].ErrorMessage);

            await _cache.StoreAsync(message);
        }

        public async Task DeleteAsync(Guid id)
        {
            _userContext.Authorize(ContactPermission.Delete);

            await _cache.DeleteAsync(id);
        }
    }
}