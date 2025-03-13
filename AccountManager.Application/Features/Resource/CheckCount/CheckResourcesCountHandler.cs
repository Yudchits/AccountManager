using AccountManager.Application.Context;
using AccountManager.Application.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Resource.CheckCount
{
    public class CheckResourcesCountHandler : IRequestHandler<CheckResourcesCountRequest, CheckResourcesCountResponse>
    {
        private readonly IResourceRepository _repository;
        private readonly UserContext _userContext;

        public CheckResourcesCountHandler(IResourceRepository repository, UserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }

        public async Task<CheckResourcesCountResponse> Handle(CheckResourcesCountRequest request, CancellationToken cancellationToken)
        {
            bool any = await _repository.CheckCountAsync(_userContext.UserId);
            
            return new CheckResourcesCountResponse
            {
                Any = any
            };
        }
    }
}
