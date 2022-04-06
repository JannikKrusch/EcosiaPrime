using EcosiaPrime.Contracts.Enums;

namespace EcosiaPrime.Contracts.Models
{
    public class Subscription
    {
        private string _startDate;
        private string _endDate;
        private PaymentMethod _paymentMethod;
        private SubscriptionType _subscriptionType;

        public string GetStartDate()
        {
            return this._startDate;
        }

        public void SetStartDate(string startDate)
        {
            this._startDate = startDate;
        }

        public string GetEndDate()
        {
            return this._endDate;
        }

        public void SetEndDate(string endDate)
        {
            this._endDate = endDate;
        }

        public PaymentMethod GetPaymentMethod()
        {
            return this._paymentMethod;
        }

        public void SetPaymentMethod(PaymentMethod paymentMethod)
        {
            this._paymentMethod = paymentMethod;
        }

        public SubscriptionType GetSubscriptionType()
        {
            return this._subscriptionType;
        }

        public void SetSubscriptionType(SubscriptionType subscriptionType)
        {
            this._subscriptionType = subscriptionType;
        }
    }
}