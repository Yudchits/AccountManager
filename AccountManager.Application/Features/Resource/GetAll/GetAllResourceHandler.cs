using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Resource.GetAll
{
    public class GetAllResourceHandler : IRequestHandler<GetAllResourceRequest, ICollection<GetAllResourceResponse>>
    {
        private readonly IResourceRepository _repository;
        private readonly IMapper _mapper;

        public GetAllResourceHandler(IResourceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ICollection<GetAllResourceResponse>> Handle(GetAllResourceRequest request, CancellationToken cancellationToken)
        {
            var resources = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<GetAllResourceResponse>>(resources);
        }
    }
}