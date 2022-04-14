namespace EcosiaPrime.Contracts.Models
{
    public class Subscription
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string PaymentMethod { get; set; }
        public string SubscriptionType { get; set; }
    }
}