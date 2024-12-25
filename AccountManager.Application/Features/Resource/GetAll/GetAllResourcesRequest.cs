using MediatR;
using System.Collections.Generic;

namespace AccountManager.Application.Features.Resource.GetAll
{
    public sealed record GetAllResourcesRequest : IRequest<ICollection<GetAllResourcesResponse>>;
}
