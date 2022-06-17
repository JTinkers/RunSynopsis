using FluentValidation;
using RunSynopsis.Domain.Contact.Entities;

namespace RunSynopsis.Domain.Contact.Validators
{
    internal class NewMessageValidator : AbstractValidator<Message>
    {
        public NewMessageValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Mail)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Body)
                .NotNull()
                .NotEmpty();
        }
    }
}