using MediatR;

namespace AccountManager.Application.Features.Delete
{
    public sealed record DeleteAccountRequest(int Id) : IRequest<DeleteAccountResponse>
}