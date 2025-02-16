using MediatR;
using System.Collections.Generic;

namespace AccountManager.Application.Features.Resource.GetAllDesc
{
    public sealed record GetAllDescResourcesRequest : IRequest<ICollection<GetAllDescResourcesResponse>>;
}
