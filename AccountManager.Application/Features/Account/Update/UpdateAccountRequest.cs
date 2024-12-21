using MediatR;

namespace AccountManager.Application.Features.Account.Update
{
    public sealed record UpdateAccountRequest(int Id, string Login, string Password) : IRequest<UpdateAccountResponse>;
}