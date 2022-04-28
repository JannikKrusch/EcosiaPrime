using MongoDB.Bson;
using MongoDB.Driver;

namespace EcosiaPrime.MongoDB
{
    public class MongoDBRepository : IMongoDBRepository
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly MongoDBConfiguration _mongoDBConfiguration;

        public MongoDBRepository(MongoDBConfiguration mongoDBConfiguration)
        {
            _mongoDBConfiguration = mongoDBConfiguration;
            var client = new MongoClient();
            _mongoDatabase = client.GetDatabase(_mongoDBConfiguration.DataBaseName);
        }

        /// <summary>
        /// Gibt die MongoDB Configuration zurück
        /// </summary>
        /// <returns></returns>
        public MongoDBConfiguration GetMongoDBConfiguration()
        {
            return _mongoDBConfiguration;
        }

        /// <summary>
        /// Trägt einen Eintrag in die Datenbank ein
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        public async Task<bool> InsertRecordAsync<T>(string collectionName, T record)
        {
            try
            {
                var collection = _mongoDatabase.GetCollection<T>(collectionName);
                await collection.InsertOneAsync(record).ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Holt einen Eintrag aus der Datenbank per ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> LoadRecordByIdAsync<T>(string collectionName, string id)
        {
            var collection = _mongoDatabase.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("_id", id);
            var result = await collection.FindAsync(filter).ConfigureAwait(false);
            return result.FirstOrDefault();
        }

        /// <summary>
        /// Holt alle Einträge aus der Datenbank
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> LoadRecordsAsync<T>(string collectionName)
        {
            var collection = _mongoDatabase.GetCollection<T>(collectionName);
            var response = await collection.FindAsync(new BsonDocument()).ConfigureAwait(false);
            var result = await response.ToListAsync().ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// Löscht einen Eintrag aus der Datenbank per ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteRecordAsync<T>(string collectionName, string id)
        {
            var colletion = _mongoDatabase.GetCollection<T>(collectionName);

            var filter = Builders<T>.Filter.Eq("_id", id);
            var result = await colletion.DeleteOneAsync(filter).ConfigureAwait(false);

            return result.IsAcknowledged;
        }

        /// <summary>
        /// Ersetzt einen Eintrag per ID bzw. erstellt einen neuen, wenn es diesen noch nicht gibt
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="id"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        public async Task<bool> UpsertRecordAsync<T>(string collectionName, string id, T record)
        {
            var collection = _mongoDatabase.GetCollection<T>(collectionName);

            var result = await collection.ReplaceOneAsync(new BsonDocument("_id", id), record,
                new ReplaceOptions
                {
                    IsUpsert = true
                }
                ).ConfigureAwait(false);

            return result.IsAcknowledged;
        }
    }
}