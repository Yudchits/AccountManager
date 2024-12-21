﻿using AccountManager.Application.Repositories;
using AccountManager.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Delete
{
    public class DeleteAccountHandler : IRequestHandler<DeleteAccountRequest, DeleteAccountResponse>
    {
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;

        public DeleteAccountHandler(IAccountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DeleteAccountResponse> Handle(DeleteAccountRequest request, CancellationToken cancellationToken)
        {
            var account = _mapper.Map<Account>(request);
            await _repository.DeleteAsync(account);
            return _mapper.Map<DeleteAccountResponse>(account);
        }
    }
}
