using CustomerRegister.Application.ViewModels;
using CustomerRegister.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace CustomerRegister.Application.Queries.GetAllCustomers
{

    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerViewModel>>
    {

        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository, IConfiguration configuration)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerViewModel>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync();

            var phones = new List<PhoneViewModel>();

            foreach (var customer in customers)
            {
                foreach (var phone in customer.Phones)
                {
                    phones.Add(new PhoneViewModel(phone.DDD, phone.PhoneNumber, phone.PhoneType));
                }
            }

            return customers.Select(c => new CustomerViewModel(c.Id, c.FullName, c.Email, phones)).ToList();
        }
    }

}