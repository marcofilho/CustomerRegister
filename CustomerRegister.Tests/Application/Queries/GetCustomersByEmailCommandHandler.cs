using CustomerRegister.Application.Queries.GetCustomerByEmail;
using CustomerRegister.Core.Entities;
using CustomerRegister.Core.Repositories;
using Moq;

namespace CustomerRegister.Tests.Application.Queries
{
    public class GetCustomersByEmailCommandHandler
    {
        [Fact]
        public async Task InputDataIsOk_Executed_Return_Customer_By_Email()
        {
            var phone = new Phone(27, "998741986");
            var phonesList = new List<Phone>() { phone };

            var customer = new Customer("Marco Filho", "998741986", phonesList);

            var customerRepositoryMock = new Mock<ICustomerRepository>();

            customerRepositoryMock.Setup(cs => cs.GetByEmailAsync(customer.Email).Result).Returns(customer);

            var getCustomerByEmailQuery = new GetCustomerByEmailQuery(customer.Email);
            var getCustomerByEmailQueryHandler = new GetCustomerByEmailQueryHandler(customerRepositoryMock.Object);


            var customerDTO = await getCustomerByEmailQueryHandler.Handle(getCustomerByEmailQuery, new CancellationToken());


            Assert.NotNull(customerDTO);
            Assert.Equal(customerDTO.FullName, customer.FullName);
            Assert.Equal(customerDTO.Email, customer.Email);

            customerRepositoryMock.Verify(pr => pr.GetByEmailAsync(customer.Email).Result, Times.Once);
        }
    }
}
