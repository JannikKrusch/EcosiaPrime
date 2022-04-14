using EcosiaPrime.Contracts.Models;

namespace EcosiaPrime.MongoDB
{
    public class MongoDBService : IMongoDBService
    {
        private readonly IMongoDBRepository _mongoDBRepository;

        public MongoDBService(IMongoDBRepository mongoDBRepository)
        {
            _mongoDBRepository = mongoDBRepository;
        }

        /*
         * Basic Methods
        */

        public MongoDBConfiguration GetMongoDBConfiguration()
        {
            return _mongoDBRepository.GetMongoDBConfiguration();
        }

        public async Task<bool> InsertRecordAsync<T>(string collectionName, T record)
        {
            var successful = await _mongoDBRepository.InsertRecordAsync<T>(collectionName, record);
            return successful;
        }

        public async Task<T> LoadRecordByIdAsync<T>(string collectionName, string id)
        {
            var record = await _mongoDBRepository.LoadRecordByIdAsync<T>(collectionName, id);
            return record;
        }

        public async Task<IEnumerable<T>> LoadRecordsAsync<T>(string collectionName)
        {
            var records = await _mongoDBRepository.LoadRecordsAsync<T>(collectionName);
            return records;
        }

        public async Task<bool> DeleteRecordAsync<T>(string collectionName, string id)
        {
            var successful = await _mongoDBRepository.DeleteRecordAsync<T>(collectionName, id);
            return successful;
        }

        public async Task<bool> UpsertRecordAsync<T>(string collectionName, string id, T record)
        {
            var successful = await _mongoDBRepository.UpsertRecordAsync<T>(collectionName, id, record);
            return successful;
        }

        /*
         * Sort Methods 
        */

        public async Task<IEnumerable<Client>> SortRecordByIdAsync(string collectionName)
        {
            var records = await LoadRecordsAsync<Client>(collectionName).ConfigureAwait(false);
            var sortedRecords = records.OrderBy(x => x.Id);
            return sortedRecords;
        }

        public async Task<IEnumerable<Client>> SortRecordByFirstNameAsync(string collectionName)
        {
            var records = await LoadRecordsAsync<Client>(collectionName).ConfigureAwait(false);
            var sortedRecords = records.OrderBy(x => x.FirstName);
            return sortedRecords;
        }

        public async Task<IEnumerable<Client>> SortRecordByLastNameAsync(string collectionName)
        {
            var records = await LoadRecordsAsync<Client>(collectionName).ConfigureAwait(false);
            var sortedRecords = records.OrderBy(x => x.LastName);
            return sortedRecords;
        }

        public async Task<IEnumerable<Client>> SortRecordByEmailAsync(string collectionName)
        {
            var records = await LoadRecordsAsync<Client>(collectionName).ConfigureAwait(false);
            var sortedRecords = records.OrderBy(x => x.Email);
            return sortedRecords;
        }

        public async Task<IEnumerable<Client>> SortRecordByCountyAsync(string collectionName)
        {
            var records = await LoadRecordsAsync<Client>(collectionName).ConfigureAwait(false);
            var sortedRecords = records.OrderBy(x => x.Address.Country);
            return sortedRecords;
        }

        public async Task<IEnumerable<Client>> SortRecordBySubscriptionTypeAsync(string collectionName)
        {
            var records = await LoadRecordsAsync<Client>(collectionName).ConfigureAwait(false);
            var sortedRecords = records.OrderBy(x => x.Subscription.SubscriptionType);
            return sortedRecords;
        }
    }
}