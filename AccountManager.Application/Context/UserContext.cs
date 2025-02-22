using System;

namespace AccountManager.Application.Context
{
    public class UserContext
    {
        private bool isConfigured = false;

        public int UserId { get; private set; }
        public string CryptoKey { get; private set; }

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