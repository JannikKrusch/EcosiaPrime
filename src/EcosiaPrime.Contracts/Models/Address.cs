namespace EcosiaPrime.Contracts.Models
{
    public class Address
    {
        public string Country { get; set; }
        public string State { get; set; }
        public int PostCode { get; set; }
        public string City { get; set; }
        public int HouseNumber { get; set; }
        public string Street { get; set; }
    }
}