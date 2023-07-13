using CustomerRegister.Core.DTOs;
using MediatR;

namespace CustomerRegister.Application.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<Unit>
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<PhoneDTO> Phones { get; set; }
    }
}
