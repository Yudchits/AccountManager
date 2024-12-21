using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Account.GetAll
{
    public class GetAllAccountHandler : IRequestHandler<GetAllAccountRequest, ICollection<GetAllAccountResponse>>
    {
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;

        public GetAllAccountHandler(IAccountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<GetAllAccountResponse>> Handle(GetAllAccountRequest request, CancellationToken cancellationToken)
        {
            var accounts = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<GetAllAccountResponse>>(accounts);
        }
    }
}