using MediatR;
using System.Collections.Generic;

namespace AccountManager.Application.Features.Resource.GetAllShort
{
    public sealed record GetAllShortResourcesRequest : IRequest<ICollection<GetAllShortResourcesResponse>>
    {
    }
}