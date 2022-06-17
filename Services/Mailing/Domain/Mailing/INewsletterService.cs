namespace RunSynopsis.Domain.Mailing
{
    public interface INewsletterService
    {
        Task SignUpAsync(string mail);

        Task SignOutAsync(Guid identifier);
    }
}