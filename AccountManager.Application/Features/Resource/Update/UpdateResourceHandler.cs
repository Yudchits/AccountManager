using AccountManager.Application.Repositories;
using AccountManager.Application.Utilities.Resource.Image;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Resource.Update
{
    public class UpdateResourceHandler : IRequestHandler<UpdateResourceRequest, UpdateResourceResponse>
    {
        private readonly IResourceRepository _repository;
        private readonly IMapper _mapper;
        private readonly IResourceImageUtility _imagePathUtility;

        public UpdateResourceHandler
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

        public async Task<UpdateResourceResponse> Handle(UpdateResourceRequest request, CancellationToken cancellationToken)
        {
            var resourceDb = _mapper.Map<Domain.Entities.Resource>(request);
            resourceDb.ImagePath = _imagePathUtility.MoveToDbPath(request.ImagePath);

            await _repository.UpdateAsync(resourceDb);
            return new UpdateResourceResponse();
        }
    }
}