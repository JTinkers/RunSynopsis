using RunSynopsis.Domain.Auth;
using RunSynopsis.Domain.Auth.Entities;
using RunSynopsis.Domain.Auth.Payloads;

namespace RunSynopsis.Server.Api
{
    public class Mutation
    {
        public async Task<Token> SignInAsync(
            IAuthService service,
            string username,
            string password)
        {
            return await service.SignInAsync(username, password);
        }

        public async Task<bool> UpdateUserAsync(
            IAuthService service,
            [ID] long userId,
            UpdateUserRequest request)
        {
            await service.UpdateUserAsync(userId, request);

            return true;
        }

        public async Task<bool> GrantAsync(
            IAuthService service,
            [ID] long userId,
            string type,
            string value)
        {
            await service.GrantAsync(userId, type, value);

            return true;
        }

        public async Task<bool> RevokeAsync(
            IAuthService service,
            [ID] long userId,
            string type,
            string value)
        {
            await service.RevokeAsync(userId, type, value);

            return true;
        }
    }
}