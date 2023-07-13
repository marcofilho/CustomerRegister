namespace CustomerRegister.Core.Entities
{
    public class Customer : BaseEntity
    {
        public Customer(string fullName, string email, List<Phone> phones)
        {
            FullName = fullName;
            Email = email;

            Phones = phones;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public List<Phone> Phones { get; private set; }


        public void Login()
        {

        }

        public void Update(string fullName, string email, List<Phone> phones)
        {
            FullName = fullName;
            Email = email;
            Phones = phones;
        }
    }
}
