namespace RunSynopsis.Domain.Auth.Ports
{
    internal interface IHasher
    {
        string Create(string input);

        bool Verify(string input, string hashed);
    }
}