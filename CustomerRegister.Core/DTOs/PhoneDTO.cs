using CustomerRegister.Core.Enums;

namespace CustomerRegister.Core.DTOs
{
    public class PhoneDTO
    {
        public PhoneDTO(int ddd, string phoneNumber, PhoneTypeEnum phoneType)
        {
            DDD = ddd;
            PhoneNumber = phoneNumber;
            PhoneType = phoneType;

        }
        public int DDD { get; private set; }
        public string PhoneNumber { get; private set; }
        public PhoneTypeEnum PhoneType { get; private set; }
    }
}
