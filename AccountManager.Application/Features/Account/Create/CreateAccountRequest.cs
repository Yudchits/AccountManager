using MediatR;

namespace AccountManager.Application.Features.Account.Create
{
    public sealed record CreateAccountRequest(int ResourceId, string Name, string Login, string Password, int UserId) : IRequest<CreateAccountResponse>
    {
    }
}