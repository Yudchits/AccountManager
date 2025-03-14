using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AccountManager.Application.Utilities.Resource.Image;

namespace AccountManager.Application.Features.Resource.Create
{
    public class CreateResourceHandler : IRequestHandler<CreateResourceRequest, CreateResourceResponse>
    {
        private readonly IResourceRepository _repository;
        private readonly IMapper _mapper;
        private readonly IResourceImageUtility _imagePathUtility;

        public CreateResourceHandler
        (
            IResourceRepository repository, 
            IMapper mapper,
            IResourceImageUtility imagePathUtility
        )
        {
            _repository = repository;
            _mapper = mapper;
            _imagePathUtility = imagePathUtility;
        }

        public async Task<CreateResourceResponse> Handle(CreateResourceRequest request, CancellationToken cancellationToken)
        {
            var resourceDb = _mapper.Map<Domain.Entities.Resource>(request);
            resourceDb.ImagePath = _imagePathUtility.MoveToDbPath(request.ImagePath);
            
            await _repository.CreateAsync(resourceDb);
            return _mapper.Map<CreateResourceResponse>(resourceDb);
        }
    }
}