using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosiaPrime.Contracts.Constants
{
    public static class SearchFunctionConstants
    {
        public static readonly List<string> SearchFunctions = new List<string>
        {
            SearchForID,
            SearchForFirstname,
            SearchForLastName,
            SearchForEmail,
            SearchForCountry,
            SearchForState,
            SearchForCity,
            SearchForPostCode,
            SearchForStreet,
            SearchForTimeSpan,
            SearchForPaymentOption,
            SearchForSubscriptionOption
        };

        public const string SearchForID = "ID";
        public const string SearchForFirstname = "Vorname";
        public const string SearchForLastName = "Nachname";
        public const string SearchForEmail = "Email";
        public const string SearchForCountry = "Land";
        public const string SearchForState = "Bundesland";
        public const string SearchForCity = "Stadt";
        public const string SearchForPostCode = "Postleitzahl";
        public const string SearchForStreet = "Straße";
        public const string SearchForTimeSpan = "Start- & Enddatum";
        public const string SearchForPaymentOption = "Bezahloptionen";
        public const string SearchForSubscriptionOption = "Abonnementoptionen";
    }
}
