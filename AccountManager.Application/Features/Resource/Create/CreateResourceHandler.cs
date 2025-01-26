using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Resource.Create
{
    public class CreateResourceHandler : IRequestHandler<CreateResourceRequest, CreateResourceResponse>
    {
        private readonly IResourceRepository _repository;
        private readonly IMapper _mapper;

        public CreateResourceHandler(IResourceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateResourceResponse> Handle(CreateResourceRequest request, CancellationToken cancellationToken)
        {
            var resourceDb = _mapper.Map<Domain.Entities.Resource>(request);
            await _repository.CreateAsync(resourceDb);
            return _mapper.Map<CreateResourceResponse>(resourceDb);
        }
    }
}