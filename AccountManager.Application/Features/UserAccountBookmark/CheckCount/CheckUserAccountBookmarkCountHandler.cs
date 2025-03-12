using AccountManager.Application.Common.Exceptions;
using AccountManager.Application.Context;
using AccountManager.Application.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.UserAccountBookmark.CheckCount
{
    public class CheckUserAccountBookmarkCountHandler : IRequestHandler<CheckUserAccountBookmarkCountRequest, CheckUserAccountBookmarkCountResponse>
    {
        private readonly IUserAccountBookmarkRepository _repository;
        private readonly UserContext _userContext;

        public CheckUserAccountBookmarkCountHandler(IUserAccountBookmarkRepository repository, UserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }

        public async Task<CheckUserAccountBookmarkCountResponse> Handle(CheckUserAccountBookmarkCountRequest request, CancellationToken cancellationToken)
        {
            int count = await _repository.GetCountByUserIdAsync(_userContext.UserId);
            if (count >= 3)
            {
                throw new UserAccountBookmarkException();
            }

            return new CheckUserAccountBookmarkCountResponse
            {
                Count = count
            };
        }
    }
}