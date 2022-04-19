
namespace EcosiaPrime.Gui
{
    public interface IGuiService
    {
        bool AreAdressInputFieldsEmpty(TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber);
        bool ArePaymentSubscriptionInputFieldsEmpty(TextBox startDate, TextBox endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        bool ArePersonInputFieldsEmpty(TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password);
        bool ArePersonInputFieldsEmptyExeptId(TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password);
        Task CreateClientAsync(Label responseLabel, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber, TextBox startDate, TextBox endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        Task DeleteClientAsync(Label responseLabel, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber, TextBox startDate, TextBox endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        Task<bool> DoesIdExist(string collectionName, string id);
        string GetPaymentMethod(string paymentString);
        string GetSubscriptionType(string subscriptionTypeString);
        string InvokeComboBox(ComboBox comboBox);
        Task Option(string options, Label responseLabel, ComboBox filter, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber, TextBox startDate, TextBox endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        Task ShowClientsAsync(ComboBox filter, ListView table, string id);
        void StartButtonPressed(string options, Label responseLabel, ComboBox filter, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber, TextBox startDate, TextBox endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        Task UpdateClientAsync(Label responseLabel, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber, TextBox startDate, TextBox endDate, ComboBox paymentMethod, ComboBox subscriptionType);
    }
}