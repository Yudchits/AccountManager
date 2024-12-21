using MediatR;

namespace AccountManager.Application.Features.Resource.Create
{
    public sealed record CreateResourceRequest(int Id, string Name, string ImagePath): IRequest<CreateResourceResponse>
}