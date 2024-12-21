using MediatR;
using System.Collections.Generic;

namespace AccountManager.Application.Features.Resource.GetAll
{
    public sealed record GetAllResourceRequest : IRequest<ICollection<GetAllResourceResponse>>;
}
