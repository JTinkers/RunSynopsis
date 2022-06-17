using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Domain.Auth
{
    public interface IUserContext
    {
        User? GetUser();

        void SetUser(User? user);

        void Authorize<TEnum>(TEnum flag);
    }
}