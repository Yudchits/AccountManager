﻿using AccountManager.Application.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Resource.Update
{
    public class UpdateResourceHandler : IRequestHandler<UpdateResourceRequest, UpdateResourceResponse>
    {
        private readonly IResourceRepository _repository;
        private readonly IMapper _mapper;

        public UpdateResourceHandler(IResourceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateResourceResponse> Handle(UpdateResourceRequest request, CancellationToken cancellationToken)
        {
            var resourceDb = _mapper.Map<Domain.Entities.Resource>(request);
            await _repository.UpdateAsync(resourceDb);
            return new UpdateResourceResponse();
        }
    }
}