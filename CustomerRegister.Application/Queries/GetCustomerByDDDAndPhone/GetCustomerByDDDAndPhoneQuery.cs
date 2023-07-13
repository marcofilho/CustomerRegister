using CustomerRegister.Core.DTOs;
using MediatR;

namespace CustomerRegister.Application.Queries.GetCustomerByDDDAndPhone
{
    public class GetCustomerByDDDAndPhoneQuery : IRequest<CustomerDTO>
    {

        public GetCustomerByDDDAndPhoneQuery(int dDD, string phoneNumber)
        {
            DDD = dDD;
            PhoneNumber = phoneNumber;
        }

        public int DDD { get; private set; }
        public string PhoneNumber { get; private set; }
    }
}
