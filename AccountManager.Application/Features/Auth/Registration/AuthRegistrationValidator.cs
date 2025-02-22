using FluentValidation;

namespace AccountManager.Application.Features.Auth.Registration
{
    public class AuthRegistrationValidator : AbstractValidator<AuthRegistrationRequest>
    {
        public AuthRegistrationValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(r => r.Login)
                .MinimumLength(4).WithMessage("Минимальная длина 4 символа");

            RuleFor(r => r.Password)
                .MinimumLength(8).WithMessage("Минимальная длина 8 символов");
        }
    }
}