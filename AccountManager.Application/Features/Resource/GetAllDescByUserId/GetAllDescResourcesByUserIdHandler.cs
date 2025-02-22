using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Resource.GetAllDescByUserId
{
    public class GetAllDescResourcesByUserIdHandler : IRequestHandler<GetAllDescResourcesByUserIdRequest, ICollection<GetAllDescResourcesByUserIdResponse>>
    {
        private readonly IResourceRepository _repository;
        private readonly IMapper _mapper;

        public GetAllDescResourcesByUserIdHandler(IResourceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ICollection<GetAllDescResourcesByUserIdResponse>> Handle(GetAllDescResourcesByUserIdRequest request, CancellationToken cancellationToken)
        {
            var resources = await _repository.GetAllDescByUserIdAsync(request.UserId);
            return _mapper.Map<ICollection<GetAllDescResourcesByUserIdResponse>>(resources);
        }
    }
}