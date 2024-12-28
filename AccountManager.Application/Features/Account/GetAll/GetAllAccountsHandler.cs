using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Account.GetAll
{
    public class GetAllAccountsHandler : IRequestHandler<GetAllAccountsRequest, ICollection<GetAllAccountsResponse>>
    {
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;

        public GetAllAccountsHandler(IAccountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<GetAllAccountsResponse>> Handle(GetAllAccountsRequest request, CancellationToken cancellationToken)
        {
            var accounts = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<GetAllAccountsResponse>>(accounts);
        }
    }
}