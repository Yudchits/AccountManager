using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Resource.GetAllDesc
{
    public class GetAllDescResourcesHandler : IRequestHandler<GetAllDescResourcesRequest, ICollection<GetAllDescResourcesResponse>>
    {
        private readonly IResourceRepository _repository;
        private readonly IMapper _mapper;

        public GetAllDescResourcesHandler(IResourceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ICollection<GetAllDescResourcesResponse>> Handle(GetAllDescResourcesRequest request, CancellationToken cancellationToken)
        {
            var resources = await _repository.GetAllDescAsync();
            return _mapper.Map<ICollection<GetAllDescResourcesResponse>>(resources);
        }
    }
}