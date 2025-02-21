using MediatR;

namespace AccountManager.Application.Features.Auth.Registration
{
    public sealed record AuthRegistrationRequest(string Login, string Password) : IRequest<AuthRegistrationResponse>
    {
    }
}