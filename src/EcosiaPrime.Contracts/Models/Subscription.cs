using EcosiaPrime.Contracts.Enums;

namespace EcosiaPrime.Contracts.Models
{
    public class Subscription
    {
        private string _startDate;
        private string _endDate;
        private PaymentMethod _paymentMethod;
        private SubscriptionType _subscriptionType;

        public string StartDate { get => _startDate; set => _startDate = value; }
        public string EndDate { get => _endDate; set => _endDate = value; }
        public PaymentMethod PaymentMethod { get => _paymentMethod; set => _paymentMethod = value; }
        public SubscriptionType SubscriptionType { get => _subscriptionType; set => _subscriptionType = value; }
    }
}