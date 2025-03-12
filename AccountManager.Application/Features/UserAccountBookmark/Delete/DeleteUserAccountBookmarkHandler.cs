using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.UserAccountBookmark.Delete
{
    public class DeleteUserAccountBookmarkHandler : IRequestHandler<DeleteUserAccountBookmarkRequest, DeleteUserAccountBookmarkResponse>
    {
        private readonly IUserAccountBookmarkRepository _repository;
        private readonly IMapper _mapper;

        public DeleteUserAccountBookmarkHandler(IUserAccountBookmarkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DeleteUserAccountBookmarkResponse> Handle(DeleteUserAccountBookmarkRequest request, CancellationToken cancellationToken)
        {
            var bookmarkDb = _mapper.Map<Domain.Entities.UserAccountBookmark>(request);
            await _repository.DeleteAsync(bookmarkDb);
            return new DeleteUserAccountBookmarkResponse();
        }
    }
}