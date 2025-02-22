using FluentValidation;

namespace AccountManager.Application.Features.Account.Update
{
    public class UpdateAccountValidator : AbstractValidator<UpdateAccountRequest>
    {
        public UpdateAccountValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(a => a.Name)
                .MinimumLength(2).WithMessage("Минимальная длина 2 символа")
                .MaximumLength(32).WithMessage("Максимальная длина 32 символа");

            RuleFor(a => a.Login)
                .MinimumLength(2).WithMessage("Минимальная длина 2 символа")
                .MaximumLength(32).WithMessage("Максимальная длина 32 символа");

            RuleFor(a => a.Password)
                .MinimumLength(2).WithMessage("Минимальная длина 2 символа")
                .MaximumLength(32).WithMessage("Максимальная длина 32 символа");
        }
    }
}