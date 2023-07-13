using CustomerRegister.Core.Entities;
using CustomerRegister.Core.Enums;
using CustomerRegister.Core.Repositories;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace CustomerRegister.Infra.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly IMongoCollection<Customer> _customerCollection;

        public CustomerRepository(IMongoDatabase mongoDatabase)
        {
            _customerCollection = mongoDatabase.GetCollection<Customer>("customers");
        }

        public async Task AddAsync(Customer customer)
        {
            await _customerCollection.InsertOneAsync(customer);
        }

        public async Task DeleteAsync(Customer customer)
        {
            await _customerCollection.DeleteOneAsync(c => c.Id == customer.Id);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _customerCollection
                            .Find(p => p.Id != null)
                            .ToListAsync();
        }

        public async Task<Customer> GetByDDDAndPhoneAsync(int ddd, string phoneNumber, PhoneTypeEnum phoneTypeEnum)
        {
            var phone = new Phone(ddd, phoneNumber, phoneTypeEnum);

            Expression<Func<Customer, bool>> filter = x => x.Phones.Contains(phone);

            return await _customerCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        public async Task<Customer> GetByEmailAsync(string email)
        {
            return await _customerCollection.Find(c => c.Email == email).SingleOrDefaultAsync();
        }

        public async Task<Customer> GetByIdAsync(string id)
        {
            return await _customerCollection.Find(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            await _customerCollection.ReplaceOneAsync(c => c.Id == customer.Id, customer);
        }

    }

}
