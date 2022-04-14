namespace EcosiaPrime.MongoDB
{
    public class MongoDBConfiguration : IMongoDBConfiguration
    {
        public string DataBaseName { get; set; }
        public string CollectionName { get; set; }
    }
}