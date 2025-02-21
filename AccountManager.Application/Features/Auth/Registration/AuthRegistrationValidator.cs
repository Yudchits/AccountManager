using FluentValidation;

namespace AccountManager.Application.Features.Auth.Registration
{
    public class AuthRegistrationValidator : AbstractValidator<AuthRegistrationRequest>
    {
        public AuthRegistrationValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(r => r.Login)
                .NotEmpty().WithMessage("Поле 'Логин' не может быть пустым");

            RuleFor(r => r.Password)
                .MinimumLength(8).WithMessage("Длина поля 'Пароль' не может быть меньше 8");
        }
    }
}