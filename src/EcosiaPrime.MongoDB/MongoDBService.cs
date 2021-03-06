using EcosiaPrime.Contracts.Models;
using MongoDB.Driver;

namespace EcosiaPrime.MongoDB
{
    public class MongoDBService : IMongoDBService
    {
        public IMongoDBRepository MongoDBRepository { get; set; }

        public MongoDBService(IMongoDBRepository mongoDBRepository)
        {
            MongoDBRepository = mongoDBRepository;
        }

        /*
         * Sort Methods
        */

        /// <summary>
        /// Gibt nach ID sortiertes IEnumerable vom Typen Client zurück
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Client>> SortRecordByIdAsync(string collectionName)
        {
            var records = await MongoDBRepository.LoadRecordsAsync<Client>(collectionName).ConfigureAwait(false);
            var sortedRecords = records.OrderBy(x => x.Id);
            return sortedRecords;
        }

        /// <summary>
        /// Gibt nach Vornamen sortiertes IEnumerable vom Typen Client zurück
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Client>> SortRecordByFirstNameAsync(string collectionName)
        {
            var records = await MongoDBRepository.LoadRecordsAsync<Client>(collectionName).ConfigureAwait(false);
            var sortedRecords = records.OrderBy(x => x.FirstName);
            return sortedRecords;
        }

        /// <summary>
        /// Gibt nach Nachnamen sortiertes IEnumerable vom Typen Client zurück
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Client>> SortRecordByLastNameAsync(string collectionName)
        {
            var records = await MongoDBRepository.LoadRecordsAsync<Client>(collectionName).ConfigureAwait(false);
            var sortedRecords = records.OrderBy(x => x.LastName);
            return sortedRecords;
        }

        /// <summary>
        /// Gibt nach Email sortiertes IEnumerable vom Typen Client zurück
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Client>> SortRecordByEmailAsync(string collectionName)
        {
            var records = await MongoDBRepository.LoadRecordsAsync<Client>(collectionName).ConfigureAwait(false);
            var sortedRecords = records.OrderBy(x => x.Email);
            return sortedRecords;
        }

        /// <summary>
        /// Gibt nach Land sortiertes IEnumerable vom Typen Client zurück
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Client>> SortRecordByCountryAsync(string collectionName)
        {
            var records = await MongoDBRepository.LoadRecordsAsync<Client>(collectionName).ConfigureAwait(false);
            var sortedRecords = records.OrderBy(x => x.Address.Country);
            return sortedRecords;
        }

        /// <summary>
        /// Gibt nach Abotyp sortiertes IEnumerable vom Typen Client zurück
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Client>> SortRecordBySubscriptionTypeAsync(string collectionName)
        {
            var records = await MongoDBRepository.LoadRecordsAsync<Client>(collectionName).ConfigureAwait(false);
            var sortedRecords = records.OrderBy(x => x.Subscription.SubscriptionType);
            return sortedRecords;
        }

        /*
         * Extra Methods
        */

        /// <summary>
        /// Gibt Wahrheitswert zurück, ob ID in Datenbank existiert
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DoesIdExistAsync(string collectionName, string id)
        {
            var exists = await MongoDBRepository.LoadRecordByIdAsync<Client>(collectionName, id).ConfigureAwait(false);
            return exists != null;
        }

        /// <summary>
        /// Gibt Wahrheitswert zurück, ob Email in Datenbank existiert
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<bool> IsEmailUniqueAsync<T>(string collectionName, string email)
        {
            var filter = Builders<T>.Filter.Eq("Email", email);
            var records = await MongoDBRepository.LoadRecordsWithFilterAsync(collectionName, filter).ConfigureAwait(false);
            return !records.Any();
        }
    }
}