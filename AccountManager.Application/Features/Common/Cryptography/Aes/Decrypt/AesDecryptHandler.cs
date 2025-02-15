using AccountManager.Application.Common;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Common.Cryptography.Aes.Decrypt
{
    public class AesDecryptHandler : IRequestHandler<AesDecryptRequest, AesDecryptResponse>
    {
        private readonly AesCryptographySettings _cryptoSettings;

        public AesDecryptHandler(IOptions<AesCryptographySettings> cryptoOptions)
        {
            _cryptoSettings = cryptoOptions.Value;
        }

        public Task<AesDecryptResponse> Handle(AesDecryptRequest request, CancellationToken cancellationToken)
        {
            byte[] key;
            using (var sha256 = SHA256.Create())
            {
                key = sha256.ComputeHash(Encoding.UTF8.GetBytes(_cryptoSettings.Key));
            }

            byte[] encryptedTextBytes = Convert.FromBase64String(request.EncryptedText);
            using (var aesLg = System.Security.Cryptography.Aes.Create())
            {
                aesLg.Key = key;

                using (var msEncrypt = new MemoryStream(encryptedTextBytes))
                {
                    byte[] iv = new byte[16];
                    msEncrypt.Read(iv, 0, iv.Length);
                    aesLg.IV = iv;

                    using (var csDecrypt = new CryptoStream(
                        msEncrypt, 
                        aesLg.CreateDecryptor(), 
                        CryptoStreamMode.Read
                    ))
                    {
                        using (var msPlain = new MemoryStream())
                        {
                            csDecrypt.CopyTo(msPlain);
                            var plainText = Encoding.UTF8.GetString(msPlain.ToArray());
                            return Task.FromResult(new AesDecryptResponse(plainText));
                        }
                    }
                }
            }
        }
    }
}