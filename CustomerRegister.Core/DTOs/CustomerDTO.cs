using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegister.Core.DTOs
{
    public class CustomerDTO
    {
        public CustomerDTO(string id, string fullName, string email, List<PhoneDTO> phoneDTOs)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Phones = phoneDTOs;
        }

        public string Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public List<PhoneDTO> Phones { get; private set; }
    }
}
