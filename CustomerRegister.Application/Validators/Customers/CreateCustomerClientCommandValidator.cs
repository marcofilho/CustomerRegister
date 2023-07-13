using CustomerRegister.Application.Commands.CreateCustomer;
using FluentValidation;

namespace CustomerRegister.Application.Validators.Customers
{
    public class CreateCustomerClientCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerClientCommandValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("Invalid e-mail format!");

            RuleFor(u => u.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Full Name required!");
        }

    }
}
