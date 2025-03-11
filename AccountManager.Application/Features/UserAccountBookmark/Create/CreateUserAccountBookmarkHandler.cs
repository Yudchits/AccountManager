using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.UserAccountBookmark.Create
{
    public class CreateUserAccountBookmarkHandler : IRequestHandler<CreateUserAccountBookmarkRequest, CreateUserAccountBookmarkResponse>
    {
        private readonly IUserAccountBookmarkRepository _repository;
        private readonly IMapper _mapper;

        public CreateUserAccountBookmarkHandler(IUserAccountBookmarkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateUserAccountBookmarkResponse> Handle(CreateUserAccountBookmarkRequest request, CancellationToken cancellationToken)
        {
            var bookmarkDb = _mapper.Map<Domain.Entities.UserAccountBookmark>(request);
            await _repository.Delete(bookmarkDb);
            return new CreateUserAccountBookmarkResponse();
        }
    }
}