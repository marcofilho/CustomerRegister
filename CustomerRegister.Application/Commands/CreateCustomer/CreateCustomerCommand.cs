using CustomerRegister.Application.ViewModels;
using MediatR;

namespace CustomerRegister.Application.Commands.CreateCustomer
{

    public class CreateCustomerCommand : IRequest<string>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<PhoneViewModel> Phones { get; set; }
        public string CustomerId { get; set; }
    }

}
