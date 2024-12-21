using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Account.GetById
{
    public class GetByIdAccountHandler : IRequestHandler<GetByIdAccountRequest, GetByIdAccountResponse>
    {
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdAccountHandler(IAccountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdAccountResponse> Handle(GetByIdAccountRequest request, CancellationToken cancellationToken)
        {
            var account = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdAccountResponse>(account);
        }
    }
}