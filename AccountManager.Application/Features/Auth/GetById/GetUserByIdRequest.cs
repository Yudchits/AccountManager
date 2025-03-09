using MediatR;

namespace AccountManager.Application.Features.Auth.GetById
{
    public sealed record GetUserByIdRequest(int Id) : IRequest<GetUserByIdResponse>
    {
    }
}