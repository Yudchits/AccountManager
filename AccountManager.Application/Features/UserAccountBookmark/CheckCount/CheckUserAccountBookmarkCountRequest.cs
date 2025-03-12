using MediatR;

namespace AccountManager.Application.Features.UserAccountBookmark.CheckCount
{
    public sealed record CheckUserAccountBookmarkCountRequest : IRequest<CheckUserAccountBookmarkCountResponse>
    {
    }
}
