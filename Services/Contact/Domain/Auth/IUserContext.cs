using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Domain.Auth
{
    public interface IUserContext
    {
        User? GetUser();

        void SetUser(User? user);

        void Authorize(Permission? permission);

        void Authorize<TEnum>(TEnum permission);
    }
}