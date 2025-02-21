using AccountManager.Application.Repositories;
using AccountManager.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Auth.Registration
{
    public class AuthRegistrationHandler : IRequestHandler<AuthRegistrationRequest, AuthRegistrationResponse>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public AuthRegistrationHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AuthRegistrationResponse> Handle(AuthRegistrationRequest request, CancellationToken cancellationToken)
        {
            var userDb = _mapper.Map<User>(request);
            int id = await _repository.CreateAsync(userDb);
            return new AuthRegistrationResponse(id);
        }
    }
}