using RunSynopsis.Domain.Mailing.Ports;

namespace RunSynopsis.Domain.Mailing
{
    internal class NewsletterService : INewsletterService
    {
        private readonly INewsletterCache _repository;

        public NewsletterService(INewsletterCache repository)
        {
            _repository = repository;
        }

        public async Task SignUpAsync(string mail)
        {
            await _repository.StoreAsync(mail);
        }

        public async Task SignOutAsync(Guid identifier)
        {
            await _repository.DeleteAsync(identifier);
        }
    }
}