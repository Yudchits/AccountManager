using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Account.Update
{
    public class UpdateAccountHandler : IRequestHandler<UpdateAccountRequest, UpdateAccountResponse>
    {
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;

        public UpdateAccountHandler(IAccountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateAccountResponse> Handle(UpdateAccountRequest request, CancellationToken cancellationToken)
        {
            var account = _mapper.Map<Domain.Entities.Account>(request);
            await _repository.UpdateAsync(account);
            return _mapper.Map<UpdateAccountResponse>(account);
        }
    }
}