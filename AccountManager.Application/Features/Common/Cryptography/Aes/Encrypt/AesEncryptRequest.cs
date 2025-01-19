using MediatR;

namespace AccountManager.Application.Features.Common.Cryptography.Aes.Encrypt
{
    public sealed record AesEncryptRequest(string PlainText, string Key) : IRequest<AesEncryptResponse>
    {
    }
}
