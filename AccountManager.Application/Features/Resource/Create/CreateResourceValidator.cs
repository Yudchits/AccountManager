using FluentValidation;

namespace AccountManager.Application.Features.Resource.Create
{
    public class CreateResourceValidator : AbstractValidator<CreateResourceRequest>
    {
        public CreateResourceValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("Поле 'Название' не может быть пустым")
                .MinimumLength(2).WithMessage("Минимальная длина поля 'Название' 2 символа")
                .MaximumLength(64).WithMessage("Максимальная длина поля 'Название' 64 символа");

            RuleFor(r => r.ImagePath)
                .NotEmpty().WithMessage("Поле 'Картинка' не может быть пустым");
        }
    }
}