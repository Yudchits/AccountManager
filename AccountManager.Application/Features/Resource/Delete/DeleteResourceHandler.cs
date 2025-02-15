using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Resource.Delete
{
    public class DeleteResourceHandler : IRequestHandler<DeleteResourceRequest, DeleteResourceResponse>
    {
        private readonly IResourceRepository _repository;
        private readonly IMapper _mapper;

        public DeleteResourceHandler(IResourceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DeleteResourceResponse> Handle(DeleteResourceRequest request, CancellationToken cancellationToken)
        {
            var resourceDb = _mapper.Map<Domain.Entities.Resource>(request);
            await _repository.DeleteAsync(resourceDb);
            return new DeleteResourceResponse();
        }
    }
}