using CustomerRegister.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegister.Tests.Core.Entities
{
    public class CustomerTests
    {
        [Fact]
        public void Test_If_Customer_Creation_Works()
        {
            var phone = new Phone(27, "998741986");
            var phonesList = new List<Phone>() { phone };

            var customer = new Customer("Marco Filho", "998741986", phonesList);

            Assert.NotNull(customer);
            Assert.NotNull(customer.Phones);
            Assert.NotEmpty(customer.Phones);
            Assert.Contains(phone, customer.Phones);
        }
    }
}
