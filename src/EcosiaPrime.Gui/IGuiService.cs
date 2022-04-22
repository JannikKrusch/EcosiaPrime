using EcosiaPrime.Contracts.Models;

namespace EcosiaPrime.Gui
{
    public interface IGuiService
    {
        bool AreAdressInputFieldsEmpty(TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber);
        bool ArePaymentSubscriptionInputFieldsEmpty(DateTimePicker startDate, DateTimePicker endDate);
        bool ArePersonInputFieldsEmpty(TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password);
        bool ArePersonInputFieldsEmptyExeptId(TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password);
        List<string> CheckEmail(string email);
        IEnumerable<string> CheckInputFieldsEmpty(TextBox response, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber, DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        IEnumerable<string> CheckInputFieldsEmptyExeptID(TextBox response, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber, DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        List<string> CheckPassword(string password);
        Task<bool> CreateClientAsync(TextBox response, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber, DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        Task<bool> DeleteClientAsync(TextBox response, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber, DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        Task<bool> DoesIdExist(string collectionName, string id);
        void FillListView(ListView listView, Client client);
        void FillListView(ListView listView, IEnumerable<Client> clients);
        DateTime GetDateTime(DateTimePicker dateTimePicker);
        string[] GetFilledRow(Client client);
        string GetPaymentMethod(string paymentString);
        string GetSubscriptionType(string subscriptionTypeString);
        string InvokeComboBox(ComboBox comboBox);
        void InvokeComboBox(ComboBox comboBox, string input);
        void InvokeDateTimePicker(DateTimePicker dateTimePicker, string input);
        void InvokeListView(ListView listView, string[] input);
        void InvokeResponseTextBox(TextBox response, IEnumerable<string> lines);
        void InvokeTextBox(TextBox textBox, string input);
        bool IsStartDateAfterEndDate(DateTimePicker startDate, DateTimePicker endDate);
        Task ShowClientsAsync(ComboBox filter, ListView table, string id);
        Task<bool> UpdateClientAsync(TextBox response, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber, DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType);
    }
}