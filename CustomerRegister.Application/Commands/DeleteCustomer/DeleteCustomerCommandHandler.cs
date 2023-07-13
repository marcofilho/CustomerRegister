using CustomerRegister.Core.Repositories;
using MediatR;

namespace CustomerRegister.Application.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByEmailAsync(request.Email);

            await _customerRepository.DeleteAsync(customer);

            return Unit.Value;
        }
    }
}
