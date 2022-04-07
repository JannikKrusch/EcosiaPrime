
namespace EcosiaPrime.MongoDB
{
    public interface IMongoDBRepository
    {
        Task<bool> DeleteRecordAsync<T>(string collectionName, string id);
        Task InsertRecordAsync<T>(string collectionName, T record);
        Task<T> LoadRecordByIdAsync<T>(string collectionName, string id);
        Task<IEnumerable<T>> LoadRecordsAsync<T>(string collectionName);
        Task<bool> UpsertRecordAsync<T>(string collectionName, string id, T record);
    }
}