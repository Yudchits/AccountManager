using System;

namespace AccountManager.Application.Context
{
    public sealed class UserContext
    {
        private static readonly UserContext _instance = new UserContext();

        private bool isConfigured = false;

        public int UserId { get; private set; }
        public string CryptoKey { get; private set; }

        private UserContext()
        {
        }

        public static UserContext Instance 
        { 
            get 
            { 
                return _instance; 
            } 
        }

        public void Configure(int userId, string cryptoKey)
        {
            if (isConfigured)
            {
                throw new InvalidOperationException("UserContext уже был сконфигурирован");
            }

            isConfigured = true;
            UserId = userId;
            CryptoKey = cryptoKey;
        }
    }
}