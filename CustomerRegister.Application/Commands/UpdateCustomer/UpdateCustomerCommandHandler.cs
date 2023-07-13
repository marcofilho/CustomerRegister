using CustomerRegister.Core.Entities;
using CustomerRegister.Core.Repositories;
using MediatR;

namespace CustomerRegister.Application.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByEmailAsync(request.Email);

            var phones = request.Phones.Select(p => new Phone(p.DDD, p.PhoneNumber, p.PhoneType)).ToList();

            customer.Update(request.FullName, request.Email, phones);

            await _customerRepository.UpdateAsync(customer);

            return Unit.Value;
        }
    }
}
