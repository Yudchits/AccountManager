using AccountManager.Application.Context;
using MediatR;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Common.Cryptography.Encrypt.Aes.Encrypt
{
    public class AesEncryptHandler : IRequestHandler<AesEncryptRequest, AesEncryptResponse>
    {
        private readonly UserContext _userContext;

        public AesEncryptHandler(UserContext userContext)
        {
            _userContext = userContext;
        }

        public Task<AesEncryptResponse> Handle(AesEncryptRequest request, CancellationToken cancellationToken)
        {
            byte[] key;
            using (var sha256 = SHA256.Create())
            {
                key = sha256.ComputeHash(Encoding.UTF8.GetBytes(_userContext.CryptoKey));
            }

            using (var aesLg = System.Security.Cryptography.Aes.Create())
            {
                aesLg.Key = key;
                aesLg.GenerateIV();
                byte[] iv = aesLg.IV;

                var encryptor = aesLg.CreateEncryptor(aesLg.Key, aesLg.IV);

                using (var msEncrypt = new MemoryStream())
                {
                    msEncrypt.Write(iv, 0, iv.Length);
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] plainBytes = Encoding.UTF8.GetBytes(request.PlainText);
                        csEncrypt.Write(plainBytes, 0, plainBytes.Length);
                    }

                    var encrypted = Convert.ToBase64String(msEncrypt.ToArray());
                    return Task.FromResult(new AesEncryptResponse(encrypted));
                }
            }
        }
    }
}