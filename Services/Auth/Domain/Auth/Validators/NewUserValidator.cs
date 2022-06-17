using FluentValidation;
using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Domain.Auth.Validators
{
    internal class NewUserValidator : AbstractValidator<User>
    {
        public NewUserValidator()
        {
            RuleFor(x => x.Nickname)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.Username)
                .NotNull()
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.Mail)
                .EmailAddress()
                .WithMessage("Invalid user e-mail address");
        }
    }
}