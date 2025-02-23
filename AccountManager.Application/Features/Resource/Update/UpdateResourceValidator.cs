using FluentValidation;

namespace AccountManager.Application.Features.Resource.Update
{
    public class UpdateResourceValidator : AbstractValidator<UpdateResourceRequest>
    {
        public UpdateResourceValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(r => r.Name)
                .MinimumLength(2).WithMessage("Минимальная длина 2 символа")
                .MaximumLength(64).WithMessage("Максимальная длина 64 символа");

            RuleFor(r => r.ImagePath)
                .NotEmpty().WithMessage("Поле не может быть пустым");
        }
    }
}