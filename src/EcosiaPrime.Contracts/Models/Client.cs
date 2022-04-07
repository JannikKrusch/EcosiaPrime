namespace EcosiaPrime.Contracts.Models
{
    public class Client
    {
        private string _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        private Address _address;
        private Subscription _subscription;

        public string Id { get => _id; set => _id = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        public Address Address { get => _address; set => _address = value; }
        public Subscription Subscription { get => _subscription; set => _subscription = value; }
    }
}