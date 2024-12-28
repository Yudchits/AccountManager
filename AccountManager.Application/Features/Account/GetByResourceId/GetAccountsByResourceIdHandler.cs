using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Account.GetByResourceId
{
    public class GetAccountsByResourceIdHandler : IRequestHandler<GetAccountsByResourceIdRequest, GetAccountsByResourceIdResponse>
    {
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;

        public GetAccountsByResourceIdHandler(IAccountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<GetAccountsByResourceIdResponse> Handle(GetAccountsByResourceIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
