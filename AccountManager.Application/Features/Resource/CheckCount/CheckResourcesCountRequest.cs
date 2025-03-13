using MediatR;

namespace AccountManager.Application.Features.Resource.CheckCount
{
    public sealed record CheckResourcesCountRequest : IRequest<CheckResourcesCountResponse>
    {
    }
}