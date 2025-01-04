using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Resource.GetAllShort
{
    public class GetAllShortResourcesHandler : IRequestHandler<GetAllShortResourcesRequest, ICollection<GetAllShortResourcesResponse>>
    {
        private readonly IResourceRepository _repository;
        private readonly IMapper _mapper;

        public GetAllShortResourcesHandler(IResourceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<GetAllShortResourcesResponse>> Handle(GetAllShortResourcesRequest request, CancellationToken cancellationToken)
        {
            var resources = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<GetAllShortResourcesResponse>>(resources);
        }
    }
}