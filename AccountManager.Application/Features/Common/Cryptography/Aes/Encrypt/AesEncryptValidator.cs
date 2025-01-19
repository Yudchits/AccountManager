using FluentValidation;

namespace AccountManager.Application.Features.Common.Cryptography.Aes.Encrypt
{
    public class AesEncryptValidator : AbstractValidator<AesEncryptRequest>
    {
        public AesEncryptValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(e => e.PlainText)
                .NotEmpty().WithMessage("Текст для шифрования не может быть пустым");

            RuleFor(e => e.Key)
                .NotEmpty().WithMessage("Ключ шифрования не может быть пустым");
        }
    }
}