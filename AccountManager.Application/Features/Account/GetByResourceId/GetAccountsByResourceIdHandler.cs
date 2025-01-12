using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Account.GetByResourceId
{
    public class GetAccountsByResourceIdHandler : IRequestHandler<GetAccountsByResourceIdRequest, ICollection<GetAccountsByResourceIdResponse>>
    {
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;

        public GetAccountsByResourceIdHandler(IAccountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<GetAccountsByResourceIdResponse>> Handle(GetAccountsByResourceIdRequest request, CancellationToken cancellationToken)
        {
            var accounts = await _repository.GetByResourceIdAsync(request.ResourceId);
            var accountsDescById = accounts.OrderByDescending(a => a.Id);
            return _mapper.Map<ICollection<GetAccountsByResourceIdResponse>>(accountsDescById);
        }
    }
}