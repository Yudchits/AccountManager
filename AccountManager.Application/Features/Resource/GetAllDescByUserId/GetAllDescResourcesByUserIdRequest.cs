using MediatR;
using System.Collections.Generic;

namespace AccountManager.Application.Features.Resource.GetAllDescByUserId
{
    public sealed record GetAllDescResourcesByUserIdRequest(int UserId) : IRequest<ICollection<GetAllDescResourcesByUserIdResponse>>;
}
