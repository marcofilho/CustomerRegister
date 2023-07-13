using CustomerRegister.Core.Entities;
using CustomerRegister.Core.Enums;

namespace CustomerRegister.Core.Repositories
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task DeleteAsync(Customer customer);
        Task<Customer> GetByEmailAsync(string email);
        Task UpdateAsync(Customer customer);
        Task<Customer> GetByIdAsync(string id);
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByDDDAndPhoneAsync(int ddd, string phoneNumber, PhoneTypeEnum phoneTypeEnum); 
    }
}
