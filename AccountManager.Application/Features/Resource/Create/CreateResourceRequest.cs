using MediatR;

namespace AccountManager.Application.Features.Resource.Create
{
    public sealed record CreateResourceRequest(string Name, string ImagePath) : IRequest<CreateResourceResponse>;
}