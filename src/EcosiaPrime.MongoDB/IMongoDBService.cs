using EcosiaPrime.Contracts.Models;

namespace EcosiaPrime.MongoDB
{
    public interface IMongoDBService
    {
        Task<bool> DeleteRecordAsync<T>(string collectionName, string id);
        MongoDBConfiguration GetMongoDBConfiguration();
        Task<bool> InsertRecordAsync<T>(string collectionName, T record);
        Task<T> LoadRecordByIdAsync<T>(string collectionName, string id);
        Task<IEnumerable<T>> LoadRecordsAsync<T>(string collectionName);
        Task<IEnumerable<Client>> SortRecordByCountyAsync(string collectionName);
        Task<IEnumerable<Client>> SortRecordByEmailAsync(string collectionName);
        Task<IEnumerable<Client>> SortRecordByFirstNameAsync(string collectionName);
        Task<IEnumerable<Client>> SortRecordByIdAsync(string collectionName);
        Task<IEnumerable<Client>> SortRecordByLastNameAsync(string collectionName);
        Task<IEnumerable<Client>> SortRecordBySubscriptionTypeAsync(string collectionName);
        Task<bool> UpsertRecordAsync<T>(string collectionName, string id, T record);
    }
}