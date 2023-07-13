using CustomerRegister.Core.DTOs;
using MediatR;

namespace CustomerRegister.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<CustomerDTO>
    {
        public GetCustomerByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; private set; }
    }
}


