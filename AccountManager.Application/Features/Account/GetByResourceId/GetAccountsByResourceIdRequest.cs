using MediatR;

namespace AccountManager.Application.Features.Account.GetByResourceId
{
    public sealed record GetAccountsByResourceIdRequest(int ResourceId) : IRequest<GetAccountsByResourceIdResponse>
    {
    }
}