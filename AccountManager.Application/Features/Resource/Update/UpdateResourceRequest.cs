using MediatR;

namespace AccountManager.Application.Features.Resource.Update
{
    public sealed record UpdateResourceRequest(int Id, string Name, string ImagePath) : IRequest<UpdateResourceResponse>
    {
    }
}