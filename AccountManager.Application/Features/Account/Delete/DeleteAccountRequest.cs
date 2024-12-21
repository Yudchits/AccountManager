using MediatR;

namespace AccountManager.Application.Features.Account.Delete
{
    public sealed record DeleteAccountRequest(int Id) : IRequest<DeleteAccountResponse>;
}