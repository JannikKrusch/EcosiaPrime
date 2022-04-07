namespace EcosiaPrime.Contracts.Models
{
    public class Address
    {
        private string _country;
        private string _state;
        private string _postCode;
        private string _city;
        private string _streetNumber;
        private string _street;

        public string Country { get => _country; set => _country = value; }
        public string State { get => _state; set => _state = value; }
        public string PostCode { get => _postCode; set => _postCode = value; }
        public string City { get => _city; set => _city = value; }
        public string StreetNumber { get => _streetNumber; set => _streetNumber = value; }
        public string Street { get => _street; set => _street = value; }
    }
}