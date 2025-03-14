﻿using MediatR;

namespace AccountManager.Application.Features.Common.Cryptography.Encrypt.Aes.Encrypt
{
    public sealed record AesEncryptRequest(string PlainText) : IRequest<AesEncryptResponse>
    {
    }
}
