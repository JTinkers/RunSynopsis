using Microsoft.Extensions.Options;
using RunSynopsis.Application.Auth.Ports.Configuration;
using RunSynopsis.Domain.Auth.Ports;
using System.Security.Cryptography;
using System.Text;

namespace RunSynopsis.Application.Auth.Ports
{
    internal class Hasher : IHasher
    {
        private readonly string _salt;

        public Hasher(IOptions<HasherConfiguration> configuration)
        {
            _salt = configuration.Value.Salt;
        }

        public string Create(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input cannot be null or empty");

            var hash = SHA512.Create();
            var data = hash.ComputeHash(Encoding.UTF8.GetBytes(_salt + input));

            var builder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                builder.Append(data[i].ToString("x2"));

            return builder.ToString();
        }

        public bool Verify(string input, string hashed)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input cannot be null or empty");

            if (string.IsNullOrEmpty(hashed))
                throw new ArgumentException("Hash cannot be null or empty");

            return Create(input) == hashed;
        }
    }
}