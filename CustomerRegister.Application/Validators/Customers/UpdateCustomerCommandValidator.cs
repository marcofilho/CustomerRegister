using CustomerRegister.Application.Commands.UpdateCustomer;
using FluentValidation;

namespace CustomerRegister.Application.Validators.Customers
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
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
