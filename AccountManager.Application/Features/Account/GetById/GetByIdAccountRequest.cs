using MediatR;

namespace AccountManager.Application.Features.Account.GetById
{
    public sealed record GetByIdAccountRequest(int Id) : IRequest<GetByIdAccountResponse>
    {
    }
}