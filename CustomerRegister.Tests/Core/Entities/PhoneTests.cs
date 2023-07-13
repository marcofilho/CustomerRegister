using CustomerRegister.Core.Entities;

namespace CustomerRegister.Tests.Core.Entities
{
    public class PhoneTests
    {

        [Fact]
        public void Test_If_Phone_Creation_Works()
        {
            var phone = new Phone(27, "998741986");

            Assert.NotNull(phone);
        }
    }
}
