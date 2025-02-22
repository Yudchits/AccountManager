using AccountManager.Application.Common;
using AccountManager.Application.Repositories;
using AccountManager.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Features.Auth.Login
{
    public class AuthLoginHandler : IRequestHandler<AuthLoginRequest, AuthLoginResponse>
    {
        private readonly IUserRepository _repository;

        public AuthLoginHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<AuthLoginResponse> Handle(AuthLoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByLoginAsync(request.Login);
            var isPasswordCorrect = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
            if (!isPasswordCorrect)
            {
                throw new AuthorizeException(nameof(User.Password), "Неверный пароль");
            }

            return new AuthLoginResponse(user.Id);
        }
    }
}