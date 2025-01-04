using MediatR;
using System.Collections.Generic;

namespace AccountManager.Application.Features.Resource.GetAllFull
{
    public sealed record GetAllFullResourcesRequest : IRequest<ICollection<GetAllFullResourcesResponse>>;
}
