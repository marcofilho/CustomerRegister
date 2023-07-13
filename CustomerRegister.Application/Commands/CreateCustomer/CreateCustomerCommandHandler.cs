
using CustomerRegister.Application.Commands.CreateCustomer;
using CustomerRegister.Core.Entities;
using CustomerRegister.Core.Repositories;
using MediatR;

namespace CustomersRegister.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, string>
    {

        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<string> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var phones = request.Phones.Select(p => new Phone(p.DDD, p.PhoneNumber, p.PhoneType)).ToList();

            var customer = new Customer(request.FullName, request.Email, phones);

            await _customerRepository.AddAsync(customer);

            return customer.Id;
        }
    }
}
