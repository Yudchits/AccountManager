using MediatR;

namespace AccountManager.Application.Features.Auth.Login
{
    public sealed record AuthLoginRequest(string Login, string Password) : IRequest<AuthLoginResponse>
    {
    }
}