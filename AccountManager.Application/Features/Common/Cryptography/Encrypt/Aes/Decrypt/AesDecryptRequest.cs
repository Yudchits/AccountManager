using MediatR;

namespace AccountManager.Application.Features.Common.Cryptography.Encrypt.Aes.Decrypt
{
    public sealed record AesDecryptRequest(string EncryptedText) : IRequest<AesDecryptResponse>
    {
    }
}