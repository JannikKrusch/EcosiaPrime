namespace EcosiaPrime.Contracts.Models
{
    public class Client
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
        public Subscription Subscription { get; set; }
    }
}