using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _mongoDatabase = client.GetDatabase(_mongoDBConfiguration.DateBaseName);
        }

        public async Task InsertRecordAsync<T>(string collectionName, T record)
        {
            var collection = _mongoDatabase.GetCollection<T>(collectionName);
            await collection.InsertOneAsync(record).ConfigureAwait(false);
        }

        public async Task<T> LoadRecordByIdAsync<T>(string collectionName, string id)
        {
            var collection = _mongoDatabase.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("_id", id);
            var result = await collection.FindAsync(filter).ConfigureAwait(false);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> LoadRecordsAsync<T>(string collectionName)
        {
            var collection = _mongoDatabase.GetCollection<T>(collectionName);
            var response = await collection.FindAsync(new BsonDocument()).ConfigureAwait(false);
            var result = await response.ToListAsync().ConfigureAwait(false);
            return result;
        }

        public async Task<bool> DeleteRecordAsync<T>(string collectionName, string id)
        {
            var colletion = _mongoDatabase.GetCollection<T>(collectionName);

            var filter = Builders<T>.Filter.Eq("_id", id);
            var result = await colletion.DeleteOneAsync(filter).ConfigureAwait(false);

            return result.IsAcknowledged;
        }

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
