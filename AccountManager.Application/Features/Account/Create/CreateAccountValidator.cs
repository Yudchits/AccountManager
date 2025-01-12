using FluentValidation;

namespace AccountManager.Application.Features.Account.Create
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountRequest>
    {
        public CreateAccountValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(a => a.Name)
                .MinimumLength(2).WithMessage("Длина поля 'Имя' не может быть меньше 2")
                .MaximumLength(32).WithMessage("Длина поля 'Имя' не может быть больше 32");

            RuleFor(a => a.Login)
                .MinimumLength(2).WithMessage("Длина поля 'Логин' не может быть меньше 2")
                .MaximumLength(32).WithMessage("Длина поля 'Логин' не может быть больше 32");

            RuleFor(a => a.Password)
                .MinimumLength(2).WithMessage("Длина поля 'Пароль' не может быть меньше 2")
                .MaximumLength(32).WithMessage("Длина поля 'Пароль' не может быть больше 32");

            RuleFor(a => a.ResourceId)
                .NotNull().WithMessage("Данные аккаунта должны относится к ресурсу")
                .GreaterThan(0).WithMessage("Идентификатор ресурса не может быть меньше 1");
        }
    }
}