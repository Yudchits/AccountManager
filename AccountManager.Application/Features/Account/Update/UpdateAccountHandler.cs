using AccountManager.Application.Features.Common.Cryptography.Encrypt.Aes.Encrypt;
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
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateAccountHandler(IAccountRepository repository, IMediator mediator, IMapper mapper)
        {
            _repository = repository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<UpdateAccountResponse> Handle(UpdateAccountRequest request, CancellationToken cancellationToken)
        {
            var encryptResult = await _mediator.Send(new AesEncryptRequest(request.Password));

            var account = _mapper.Map<Domain.Entities.Account>(request);
            account.Password = encryptResult.EncryptedText;

            await _repository.UpdateAsync(account);
            return _mapper.Map<UpdateAccountResponse>(account);
        }
    }
}