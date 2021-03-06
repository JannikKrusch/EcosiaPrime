namespace EcosiaPrime.Contracts.Constants
{
    public static class SearchFunctionConstants
    {
        public const string SearchForID = "ID";
        public const string SearchForFirstname = "Vorname";
        public const string SearchForLastName = "Nachname";
        public const string SearchForEmail = "Email";
        public const string SearchForCountry = "Land";
        public const string SearchForState = "Bundesland";
        public const string SearchForCity = "Stadt";
        public const string SearchForPostCode = "Postleitzahl";
        public const string SearchForStreet = "Straße";
        public const string SearchForHouseNumber = "Hausnummer";
        public const string SearchForTimeSpan = "Start- & Enddatum";
        public const string SearchForPaymentOption = "Bezahloptionen";
        public const string SearchForSubscriptionOption = "Abonnementoptionen";

        public const string SeachAttributeId = "_id";
        public const string SeachAttributeFirstName = "FirstName";
        public const string SeachAttributeLastName = "LastName";
        public const string SeachAttributeEmail = "Email";
        public const string SeachAttributeCountry = "Address.Country";
        public const string SeachAttributeState = "Address.State";
        public const string SeachAttributeCity = "Address.City";
        public const string SeachAttributePostCode = "Address.PostCode";
        public const string SeachAttributeStreet = "Address.Street";
        public const string SeachAttributeHouseNumber = "Address.HouseNumber";
        public const string SeachAttributePaymentMethod = "Subscription.PaymentMethod";
        public const string SeachAttributeSubscriptionType = "Subscription.SubscriptionType";

        public const string SeachOperationEquals = "=";
        public const string SeachOperationNotEquals = "!=";
        public const string SeachOperationLessThan = "<";
        public const string SeachOperationLessThanOrEquals = "<=";
        public const string SeachOperationGreaterThan = ">";
        public const string SeachOperationGreaterThanOrEquals = ">=";

        public const string SeachLogicAnd = "&";
        public const string SeachLogicOr = "|";

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
            SearchForHouseNumber,
            SearchForTimeSpan,
            SearchForPaymentOption,
            SearchForSubscriptionOption
        };

        public static readonly List<string> SearchFilterValueMustBeInteger = new List<string>
        {
            SeachAttributePostCode,
            SeachAttributeHouseNumber,
        };

        public static readonly List<string> SearchFilterValueMustBeString = new List<string>
        {
            SeachAttributeId,
            SeachAttributeFirstName,
            SeachAttributeLastName,
            SeachAttributeEmail,
            SeachAttributeCountry,
            SeachAttributeState,
            SeachAttributeCity,
            SeachAttributeStreet,
            SeachAttributePaymentMethod,
            SeachAttributeSubscriptionType
        };

        public static readonly List<string> SearchFilterAttributeOptions = new List<string>(SearchFilterValueMustBeString)
        {
            SeachAttributePostCode,
            SeachAttributeHouseNumber,
        };

        public static readonly List<string> SearchFilterOperationOptions = new List<string>
        {
            SeachOperationEquals,
            SeachOperationNotEquals,
            SeachOperationLessThan,
            SeachOperationLessThanOrEquals,
            SeachOperationGreaterThan,
            SeachOperationGreaterThanOrEquals
        };

        public static readonly List<string> SearchFilterLogicalOptions = new List<string>
        {
            SeachLogicAnd,
            SeachLogicOr
        };
    }
}