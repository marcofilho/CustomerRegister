using CustomerRegister.Application.ViewModels;
using MediatR;

namespace CustomerRegister.Application.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<Unit>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<PhoneViewModel> Phones { get; set; }
    }
}
