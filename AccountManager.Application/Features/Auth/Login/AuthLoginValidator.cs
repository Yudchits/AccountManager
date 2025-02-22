using FluentValidation;

namespace AccountManager.Application.Features.Auth.Login
{
    public class AuthLoginValidator : AbstractValidator<AuthLoginRequest>
    {
        public AuthLoginValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(r => r.Login)
                .NotEmpty().WithMessage("Поле не может быть пустым");

            RuleFor(r => r.Password)
                .NotEmpty().WithMessage("Поле не может быть пустым");
        }
    }
}