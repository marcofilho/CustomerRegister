using CustomerRegister.Core.Entities;
using CustomerRegister.Core.Repositories;
using MongoDB.Driver;

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

        public async Task<Customer> GetByDDDAndPhoneAsync(int ddd, string phoneNumber)
        {
            var phone = new Phone(ddd, phoneNumber);

            return await _customerCollection
                           .FindAsync(p => p.Phones.Contains(phone)).Result.SingleOrDefaultAsync();
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
