using FluentValidation;

namespace AccountManager.Application.Features.Common.Cryptography.Encrypt.Aes.Decrypt
{
    public class AesDecryptValidator : AbstractValidator<AesDecryptRequest>
    {
        public AesDecryptValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(d => d.EncryptedText)
                .NotEmpty().WithMessage("Зашифрованный текст не может быть пустым");
        }
    }
}