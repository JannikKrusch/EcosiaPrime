using EcosiaPrime.Contracts.Models;

namespace EcosiaPrime.MongoDB
{
    public interface IMongoDBService
    {
        IMongoDBRepository MongoDBRepository { get; set; }

        Task<bool> DoesIdExistAsync(string collectionName, string id);

        Task<bool> IsEmailUniqueAsync<T>(string collectionName, string email);

        Task<IEnumerable<Client>> SortRecordByCountryAsync(string collectionName);

        Task<IEnumerable<Client>> SortRecordByEmailAsync(string collectionName);

        Task<IEnumerable<Client>> SortRecordByFirstNameAsync(string collectionName);

        Task<IEnumerable<Client>> SortRecordByIdAsync(string collectionName);

        Task<IEnumerable<Client>> SortRecordByLastNameAsync(string collectionName);

        Task<IEnumerable<Client>> SortRecordBySubscriptionTypeAsync(string collectionName);
    }
}