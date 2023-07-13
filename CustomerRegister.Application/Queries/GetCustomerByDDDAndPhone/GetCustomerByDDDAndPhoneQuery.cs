using CustomerRegister.Core.DTOs;
using CustomerRegister.Core.Enums;
using MediatR;

namespace CustomerRegister.Application.Queries.GetCustomerByDDDAndPhone
{
    public class GetCustomerByDDDAndPhoneQuery : IRequest<CustomerDTO>
    {

        public GetCustomerByDDDAndPhoneQuery(int dDD, string phoneNumber, PhoneTypeEnum phoneTypeEnum)
        {
            DDD = dDD;
            PhoneNumber = phoneNumber;
            PhoneType = phoneTypeEnum;
        }

        public int DDD { get; private set; }
        public string PhoneNumber { get; private set; }
        public PhoneTypeEnum PhoneType { get; private set; }
    }
}
