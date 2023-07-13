using CustomerRegister.Application.Queries.GetCustomerByEmail;
using CustomerRegister.Core.DTOs;
using CustomerRegister.Core.Repositories;
using MediatR;

namespace CustomerRegister.Application.Queries.GetCustomerByDDDAndPhone
{
    public class GetCustomerByDDDAndPhoneQueryHandler : IRequestHandler<GetCustomerByDDDAndPhoneQuery, CustomerDTO>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByDDDAndPhoneQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDTO> Handle(GetCustomerByDDDAndPhoneQuery request, CancellationToken cancellationToken)
        {
            {
                var customer = await _customerRepository.GetByDDDAndPhoneAsync(request.DDD, request.PhoneNumber, request.PhoneType);

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
