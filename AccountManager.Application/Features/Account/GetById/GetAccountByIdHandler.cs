using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Account.GetById
{
    public class GetAccountByIdHandler : IRequestHandler<GetAccountByIdRequest, GetAccountByIdResponse>
    {
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;

        public GetAccountByIdHandler(IAccountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAccountByIdResponse> Handle(GetAccountByIdRequest request, CancellationToken cancellationToken)
        {
            var account = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetAccountByIdResponse>(account);
        }
    }
}