using CustomerRegister.Core.DTOs;
using MediatR;

namespace CustomerRegister.Application.Queries.GetCustomerByEmail
{
    public class GetCustomerByEmailQuery : IRequest<CustomerDTO>
    {
        public GetCustomerByEmailQuery(string email)
        {
            Email = email;
        }

        public string Email { get; private set; }
    }
}

