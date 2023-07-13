using CustomerRegister.Application.ViewModels;
using MediatR;

namespace CustomerRegister.Application.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<List<CustomerViewModel>>
    {
        public GetAllCustomersQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}