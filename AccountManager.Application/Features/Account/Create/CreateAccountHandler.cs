using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Account.Create
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountRequest, CreateAccountResponse>
    {
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;

        public CreateAccountHandler(IAccountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateAccountResponse> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
        {
            var account = _mapper.Map<Domain.Entities.Account>(request);
            await _repository.CreateAsync(account);
            return _mapper.Map<CreateAccountResponse>(account);
        }
    }
}