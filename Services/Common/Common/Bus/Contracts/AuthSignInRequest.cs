﻿namespace RunSynopsis.Common.Bus.Contracts
{
    public class AuthSignInRequest : IAuthSignInRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public AuthSignInRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}