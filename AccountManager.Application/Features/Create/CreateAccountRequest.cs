using MediatR;

namespace AccountManager.Application.Features.Create
{
    public sealed record CreateAccountRequest(string Login, string Password) : IRequest<CreateAccountResponse>
    {
    }
}