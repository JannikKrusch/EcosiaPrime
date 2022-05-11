using EcosiaPrime.Contracts.Models;

namespace EcosiaPrime.Gui
{
    public interface IGuiService
    {
        Task<IEnumerable<string>> CreateClientAsync(string id, string firstName, string lastName, string email, string password, string country, string state, string postCode, string city, string street, string houseNumber, string startDate, string endDate, string paymentMethod, string subscriptionType);
        Task<IEnumerable<string>> DeleteClientAsync(string id);
        Task<IEnumerable<Client>> SearchAttributesAsync(string searchForString, string searchStringPrimary, string searchStringSecondary);
        Task<IEnumerable<Client>> SearchFunctionAsync(string filter, string id, string firstName, string lastName, string email, string password, string country, string state, string postCode, string city, string street, string houseNumber, string startDate, string endDate, string paymentMethod, string subscriptionType);
        Task<IEnumerable<Client>> ShowClientsAsync(string filter, string id);
        Task<IEnumerable<string>> UpdateClientAsync(string id, string firstName, string lastName, string email, string password, string country, string state, string postCode, string city, string street, string houseNumber, string startDate, string endDate, string paymentMethod, string subscriptionType);
    }
}