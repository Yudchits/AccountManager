using MediatR;
using System.Collections.Generic;

namespace AccountManager.Application.Features.Account.GetByResourceId
{
    public sealed record GetAccountsByResourceIdRequest(int ResourceId, int UserId) : IRequest<ICollection<GetAccountsByResourceIdResponse>>
    {
    }
}