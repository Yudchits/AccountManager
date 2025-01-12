using MediatR;

namespace AccountManager.Application.Features.Account.Update
{
    public sealed record UpdateAccountRequest(int Id, int ResourceId, string Name, string Login, string Password) : IRequest<UpdateAccountResponse>;
}