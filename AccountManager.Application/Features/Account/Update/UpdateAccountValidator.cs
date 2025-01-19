using FluentValidation;

namespace AccountManager.Application.Features.Account.Update
{
    public class UpdateAccountValidator : AbstractValidator<UpdateAccountRequest>
    {
        public UpdateAccountValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(a => a.Name)
                .MinimumLength(2).WithMessage("Длина имени не может быть меньше 2")
                .MaximumLength(32).WithMessage("Длина имени не может быть больше 32");

            RuleFor(a => a.Login)
                .MinimumLength(2).WithMessage("Длина логина не может быть меньше 2")
                .MaximumLength(32).WithMessage("Длина логина не может быть больше 32");

            RuleFor(a => a.Password)
                .MinimumLength(2).WithMessage("Длина пароля не может быть меньше 2")
                .MaximumLength(32).WithMessage("Длина пароля не может быть больше 32");

            RuleFor(a => a.ResourceId)
                .NotNull().WithMessage("Данные аккаунта должны относится к ресурсу")
                .GreaterThan(0).WithMessage("Идентификатор ресурса не может быть меньше 1");
        }
    }
}