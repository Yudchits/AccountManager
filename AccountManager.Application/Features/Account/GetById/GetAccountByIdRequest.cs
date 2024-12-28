using MediatR;

namespace AccountManager.Application.Features.Account.GetById
{
    public sealed record GetAccountByIdRequest(int Id) : IRequest<GetAccountByIdResponse>
    {
    }
}