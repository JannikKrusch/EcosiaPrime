namespace EcosiaPrime.Contracts.Constants
{
    public static class VisibleTextFieldListConstants
    {
        public static readonly List<string> Create = new List<string>
        {
            "idTextfield",
            "firstNameTextfield",
            "lastNameTextfield",
            "emailTextfield",
            "passwordTextfield",
            "countryTextfield",
            "stateTextfield",
            "postcodeTextfield",
            "cityTextfield",
            "streetNameTextfield",
            "houseNumberTextfield",
            "startDatePicker",
            "endDatePicker",
            "dropdownMenuPayment",
            "dropdownMenuSubscription",
            "dropdownMenuOption",
            "responseTextField"
        };

        public static readonly List<string> Delete = new List<string>
        {
            "idTextfield",
            "dropdownMenuOption",
            "responseTextField"
        };

        public static readonly List<string> Update = new List<string>(Delete);

        public static readonly List<string> Show = new List<string>(Delete)
        { 
            "dropdownMenuFilter",
        };

        public static readonly List<string> Search = new List<string>(Create)
        {
            "searchForStartDateBox",
            "searchForEndDateBox",
            "searchForPaymentMethodBox",
            "searchForSubscriptionTypeBox"
        };

        public static readonly List<string> AdvancedSearch = new List<string>
        {
            "advancedSearchfield",
            "dropdownMenuOption",
            "responseTextField"
        };
    }
}