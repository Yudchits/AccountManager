using AccountManager.Application.Common;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Common.Cryptography.Hash.Generate
{
    public class GenerateHashHandler : IRequestHandler<GenerateHashRequest, GenerateHashResponse>
    {
        private readonly UserContextSettings _userContextSettings;

        public GenerateHashHandler(IOptions<UserContextSettings> options)
        {
            _userContextSettings = options.Value;
        }

        public Task<GenerateHashResponse> Handle(GenerateHashRequest request, CancellationToken cancellationToken)
        {
            int saltSize = _userContextSettings.Salt.Length;
            int hashSize = _userContextSettings.HashSize;
            int iterations = _userContextSettings.Iterations;

            byte[] salt = Encoding.UTF8.GetBytes(_userContextSettings.Salt);
            byte[] password = Encoding.UTF8.GetBytes(request.PlainText);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(hashSize);

            byte[] hashBytes = new byte[saltSize + hashSize];
            Array.Copy(salt, 0, hashBytes, 0, saltSize);
            Array.Copy(hash, 0, hashBytes, saltSize, hashSize);

            string hashedCryptoKey = Convert.ToBase64String(hashBytes);
            return Task.FromResult(new GenerateHashResponse(hashedCryptoKey));
        }
    }
}