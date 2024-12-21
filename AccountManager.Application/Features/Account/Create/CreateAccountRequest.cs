using MediatR;

namespace AccountManager.Application.Features.Account.Create
{
    public sealed record CreateAccountRequest(string Login, string Password) : IRequest<CreateAccountResponse>
    {
    }
}