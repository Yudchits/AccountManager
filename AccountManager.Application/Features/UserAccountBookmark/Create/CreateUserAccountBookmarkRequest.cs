using MediatR;

namespace AccountManager.Application.Features.UserAccountBookmark.Create
{
    public sealed record CreateUserAccountBookmarkRequest(int UserId, int AccountId) : IRequest<CreateUserAccountBookmarkResponse>
    {
    }
}