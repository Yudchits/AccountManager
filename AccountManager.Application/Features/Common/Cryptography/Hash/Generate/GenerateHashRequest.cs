using MediatR;

namespace AccountManager.Application.Features.Common.Cryptography.Hash.Generate
{
    public sealed record GenerateHashRequest(string PlainText) : IRequest<GenerateHashResponse>
    {
    }
}
