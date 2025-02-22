using MediatR;
using System.Collections.Generic;

namespace AccountManager.Application.Features.Account.GetAll
{
    public sealed record GetAllAccountsRequest(int UserId) : IRequest<ICollection<GetAllAccountsResponse>>;
}
