namespace CustomerRegister.Application.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel(string id, string fullName, string email, List<PhoneViewModel> phones)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Phones = phones;
        }

        public string Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public List<PhoneViewModel> Phones { get; private set; }
    }
}
