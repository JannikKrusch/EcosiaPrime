
namespace EcosiaPrime.Gui
{
    public interface IGuiService
    {
        bool AreAdressInputFieldsEmpty(TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber);
        bool ArePaymentSubscriptionInputFieldsEmpty(TextBox startDate, TextBox endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        bool ArePersonInputFieldsEmpty(TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password);
        bool ArePersonInputFieldsEmptyExeptId(TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password);
        string CheckInputFieldsEmpty(Label responseLabel, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber, TextBox startDate, TextBox endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        string CheckInputFieldsEmptyExeptID(Label responseLabel, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber, TextBox startDate, TextBox endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        Task CreateClientAsync(Label responseLabel, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber, TextBox startDate, TextBox endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        Task DeleteClientAsync(Label responseLabel, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber, TextBox startDate, TextBox endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        Task<bool> DoesIdExist(string collectionName, string id);
        string GetPaymentMethod(string paymentString);
        string GetSubscriptionType(string subscriptionTypeString);
        string InvokeComboBox(ComboBox comboBox);
        void InvokeComboBox(ComboBox comboBox, string input);
        void InvokeLabel(Label label, string input);
        void InvokeListView(ListView listView, string[] input);
        void InvokeTextBox(TextBox textBox, string input);
        Task ShowClientsAsync(ComboBox filter, ListView table, string id);
        Task UpdateClientAsync(Label responseLabel, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber, TextBox startDate, TextBox endDate, ComboBox paymentMethod, ComboBox subscriptionType);
    }
}