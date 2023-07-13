using CustomerRegister.Application.Commands.CreateCustomer;
using CustomerRegister.Application.ViewModels;
using CustomerRegister.Core.Entities;
using CustomerRegister.Core.Enums;
using CustomerRegister.Core.Repositories;
using CustomersRegister.Application.Commands.CreateCustomer;
using Moq;
using Xunit;


namespace CustomerRegister.Tests.Application.Commands
{
    public class CreateCustomerCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_Return_CustomerId()
        {
            var customerRepositoryMock = new Mock<ICustomerRepository>();

            var createCustomerCommand = new CreateCustomerCommand
            {
                Email = "m.barceloslima@gmail.com",
                FullName = "Marco Antonio",
                Phones = new List<PhoneViewModel>() 
                { new PhoneViewModel(27, "998741986", PhoneTypeEnum.CELLPHONE) }
            };

            var createCustomerCommandHandler = new CreateCustomerCommandHandler(customerRepositoryMock.Object);

            var id = await createCustomerCommandHandler.Handle(createCustomerCommand, new CancellationToken());

            customerRepositoryMock.Verify(pr => pr.AddAsync(It.IsAny<Customer>()), Times.Once);
        }
    }
}
