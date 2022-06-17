namespace RunSynopsis.Common.Bus.Contracts
{
    public class AuthGetUserByIdRequest : IAuthGetUserByIdRequest
    {
        public long Id { get; set; }

        public AuthGetUserByIdRequest(long id)
        {
            Id = id;
        }
    }
}