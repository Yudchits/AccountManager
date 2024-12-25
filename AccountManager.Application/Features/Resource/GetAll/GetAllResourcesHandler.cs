using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Resource.GetAll
{
    public class GetAllResourcesHandler : IRequestHandler<GetAllResourcesRequest, ICollection<GetAllResourcesResponse>>
    {
        private readonly IResourceRepository _repository;
        private readonly IMapper _mapper;

        public GetAllResourcesHandler(IResourceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ICollection<GetAllResourcesResponse>> Handle(GetAllResourcesRequest request, CancellationToken cancellationToken)
        {
            var resources = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<GetAllResourcesResponse>>(resources);
        }
    }
}