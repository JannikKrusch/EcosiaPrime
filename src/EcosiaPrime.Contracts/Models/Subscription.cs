using EcosiaPrime.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosiaPrime.Contracts.Models
{
    public class Subscription
    {
        private string _startDate;
        private string _endDate;
        private PaymentMethod _paymentMethod;
        private SubscriptionType _subscriptionType;
    }
}
