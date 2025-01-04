using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Resource.GetAllFull
{
    public class GetAllFullResourcesHandler : IRequestHandler<GetAllFullResourcesRequest, ICollection<GetAllFullResourcesResponse>>
    {
        private readonly IResourceRepository _repository;
        private readonly IMapper _mapper;

        public GetAllFullResourcesHandler(IResourceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ICollection<GetAllFullResourcesResponse>> Handle(GetAllFullResourcesRequest request, CancellationToken cancellationToken)
        {
            var resources = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<GetAllFullResourcesResponse>>(resources);
        }
    }
}