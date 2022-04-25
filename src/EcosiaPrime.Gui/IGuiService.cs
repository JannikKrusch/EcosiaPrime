
namespace EcosiaPrime.Gui
{
    public interface IGuiService
    {
        Task<bool> CreateClientAsync(TextBox response, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox houseNumber, DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        Task<bool> DeleteClientAsync(TextBox response, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox houseNumber, DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        Task<bool> DoesIdExist(string collectionName, string id);
        Task SearchAttributesAsync(ListView table, string searchForString, string searchStringPrimary, string searchStringSecondary);
        Task SearchFunctionAsync(ListView table, ComboBox filter, TextBox response, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox houseNumber, DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType);
        Task ShowClientsAsync(ComboBox filter, ListView table, string id);
        Task<bool> UpdateClientAsync(TextBox response, TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password, TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox houseNumber, DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType);
    }
}