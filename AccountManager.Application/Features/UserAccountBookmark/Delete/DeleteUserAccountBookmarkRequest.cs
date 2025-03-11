using MediatR;

namespace AccountManager.Application.Features.UserAccountBookmark.Delete
{
    public sealed record DeleteUserAccountBookmarkRequest(int UserId, int AccountId) : IRequest<DeleteUserAccountBookmarkResponse>
    {
    }
}