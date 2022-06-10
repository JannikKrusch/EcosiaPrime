using EcosiaPrime.Contracts.Models;
using MongoDB.Driver;

namespace EcosiaPrime.Gui
{
    public interface IGuiService
    {
        Task<IEnumerable<Client>> AdvancedSearchFunctionAsync(string searchString);
        Task<IEnumerable<string>> CreateClientAsync(string id, string firstName, string lastName, string email, string password, string country, string state, string postCode, string city, string street, string houseNumber, string startDate, string endDate, string paymentMethod, string subscriptionType);
        FilterDefinition<T> CreateFilter<T>(List<List<string>> filterList);
        List<List<string>> CreateFilterListForAdvancedSearch(string filterString);
        Task<IEnumerable<string>> DeleteClientAsync(string id);
        Task<IEnumerable<Client>> SearchFunctionAsync(string filter, bool searchStartDate, bool searchEndDate, bool searchPaymentMethod, bool searchSubscriptionType, string id, string firstName, string lastName, string email, string password, string country, string state, string postCode, string city, string street, string houseNumber, string startDate, string endDate, string paymentMethod, string subscriptionType);
        Task<IEnumerable<Client>> ShowClientsAsync(string filter, string id);
        Task<IEnumerable<string>> UpdateClientAsync(string id, string firstName, string lastName, string email, string password, string country, string state, string postCode, string city, string street, string houseNumber, string startDate, string endDate, string paymentMethod, string subscriptionType);
    }
}