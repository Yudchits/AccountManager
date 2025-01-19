using MediatR;

namespace AccountManager.Application.Features.Common.Cryptography.Aes.Decrypt
{
    public sealed record AesDecryptRequest(string EncryptedText) : IRequest<AesDecryptResponse>
    {
    }
}