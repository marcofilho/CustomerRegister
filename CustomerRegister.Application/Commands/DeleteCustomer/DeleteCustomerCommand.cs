using MediatR;

namespace CustomerRegister.Application.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<Unit>
    {
        public DeleteCustomerCommand(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }
}
