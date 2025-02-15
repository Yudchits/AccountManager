using MediatR;

namespace AccountManager.Application.Features.Resource.Delete
{
    public sealed record DeleteResourceRequest(int Id) : IRequest<DeleteResourceResponse>
    {
    }
}