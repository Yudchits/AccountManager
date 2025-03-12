using MediatR;
using System.Collections.Generic;

namespace AccountManager.Application.Features.UserAccountBookmark.GetByUserId
{
    public sealed record GetBookmarkedAccountsByUserIdRequest : IRequest<ICollection<GetBookmarkedAccountsByUserIdResponse>>
    {
    }
}