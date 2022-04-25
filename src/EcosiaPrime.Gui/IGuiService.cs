using EcosiaPrime.Contracts.Models;

namespace EcosiaPrime.Gui
{
    public interface IGuiService
    {
        bool AreAdressInputFieldsEmpty(TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox houseNumber);
        bool ArePaymentSubscriptionInputFieldsEmpty(DateTimePicker startDate, DateTimePicker endDate);
        bool ArePersonInputFieldsEmpty(TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password);
        bool ArePersonInputFieldsEmptyExeptId(TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password);
        List<string> CheckEmail(string email);
        IEnumerable<string> CheckInputFieldsEmpty(TextBox response, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox houseNumber, DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        IEnumerable<string> CheckInputFieldsEmptyExeptID(TextBox response, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox houseNumber, DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        List<string> CheckNonNumberInputsForNumbers(string firstName, string lastName, string country, string state, string city, string street);
        List<string> CheckNumberInputsForNumbers(string postCode, string houseNumber);
        List<string> CheckPassword(string password);
        Task<bool> CreateClientAsync(TextBox response, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox houseNumber, DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        string CutDateString(string dateString);
        Task<bool> DeleteClientAsync(TextBox response, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox houseNumber, DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        Task<bool> DoesIdExist(string collectionName, string id);
        void FillListView(ListView listView, Client client);
        void FillListView(ListView listView, IEnumerable<Client> clients);
        DateTime GetDateTime(DateTimePicker dateTimePicker);
        string[] GetFilledRow(Client client);
        string InvokeComboBox(ComboBox comboBox);
        void InvokeComboBox(ComboBox comboBox, string input);
        void InvokeDateTimePicker(DateTimePicker dateTimePicker, string input);
        void InvokeListView(ListView listView, string[] input);
        void InvokeResponseTextBox(TextBox response, IEnumerable<string> lines);
        void InvokeTextBox(TextBox textBox, string input);
        bool IsStartDateAfterEndDate(DateTimePicker startDate, DateTimePicker endDate);
        DateTime ParseCutString(string dateString);
        Task SearchAttributesAsync(ListView table, string searchForString, string searchStringPrimary, string searchStringSecondary);
        Task SearchFunctionAsync(ListView table, ComboBox filter, TextBox response, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox houseNumber, DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        Task ShowClientsAsync(ComboBox filter, ListView table, string id);
        Task<bool> UpdateClientAsync(TextBox response, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox houseNumber, DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType);
    }
}