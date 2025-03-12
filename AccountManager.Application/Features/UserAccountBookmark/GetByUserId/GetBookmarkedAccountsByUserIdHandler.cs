using AccountManager.Application.Context;
using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.UserAccountBookmark.GetByUserId
{
    public class GetBookmarkedAccountsByUserIdHandler : IRequestHandler<GetBookmarkedAccountsByUserIdRequest, ICollection<GetBookmarkedAccountsByUserIdResponse>>
    {
        private readonly IUserAccountBookmarkRepository _repository;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public GetBookmarkedAccountsByUserIdHandler
        (
            IUserAccountBookmarkRepository repository, 
            IMapper mapper, 
            UserContext userContext
        )
        {
            _repository = repository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<ICollection<GetBookmarkedAccountsByUserIdResponse>> Handle(GetBookmarkedAccountsByUserIdRequest request, CancellationToken cancellationToken)
        {
            var accounts = await _repository.GetByUserIdAsync(_userContext.UserId);
            return _mapper.Map<ICollection<GetBookmarkedAccountsByUserIdResponse>>(accounts);
        }
    }
}