using CustomerRegister.Core.DTOs;
using CustomerRegister.Core.Enums;
using CustomerRegister.Core.Repositories;
using MediatR;

namespace CustomerRegister.Application.Queries.GetCustomerById
{

    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDTO>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            {
                var customer = await _customerRepository.GetByIdAsync(request.Id);

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