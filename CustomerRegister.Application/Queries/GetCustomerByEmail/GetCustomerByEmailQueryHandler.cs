using CustomerRegister.Core.DTOs;
using CustomerRegister.Core.Repositories;
using MediatR;

namespace CustomerRegister.Application.Queries.GetCustomerByEmail
{

    public class GetCustomerByEmailQueryHandler : IRequestHandler<GetCustomerByEmailQuery, CustomerDTO>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByEmailQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDTO> Handle(GetCustomerByEmailQuery request, CancellationToken cancellationToken)
        {
            {
                var customer = await _customerRepository.GetByEmailAsync(request.Email);

                if (customer == null)
                    return null;

                var phones = customer.Phones.Select(p => new PhoneDTO(p.DDD, p.PhoneNumber, p.PhoneType)).ToList();

                return new CustomerDTO(
                    customer.Id,
                    customer.FullName,
                    customer.Email,
                    phones
                );
            }
        }
    }
}