using EcosiaPrime.Contracts.Models;

namespace EcosiaPrime.MongoDB
{
    public interface IMongoDBService
    {
        Task<bool> DeleteRecordAsync<T>(string collectionName, string id);
        Task<bool> InsertRecordAsync<T>(string collectionName, T record);
        Task<T> LoadRecordByIdAsync<T>(string collectionName, string id);
        Task<IEnumerable<T>> LoadRecordsAsync<T>(string collectionName);
        Task<IEnumerable<Client>> SortRecordByEmail(string collectionName);
        Task<IEnumerable<Client>> SortRecordByFirstName(string collectionName);
        Task<IEnumerable<Client>> SortRecordById(string collectionName);
        Task<IEnumerable<Client>> SortRecordByLastName(string collectionName);
        Task<bool> UpsertRecordAsync<T>(string collectionName, string id, T record);
    }
}