using RunSynopsis.Domain.Mailing;

namespace RunSynopsis.Server.Api
{
    public class Mutation
    {
        public async Task<bool> SignUpAsync(INewsletterService service, string mail)
        {
            await service.SignUpAsync(mail);

            return true;
        }

        public async Task<bool> SignOutAsync(INewsletterService service, Guid identifier)
        {
            await service.SignOutAsync(identifier);

            return true;
        }
    }
}