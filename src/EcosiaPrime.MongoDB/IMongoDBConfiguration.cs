namespace EcosiaPrime.MongoDB
{
    public interface IMongoDBConfiguration
    {
        public string CollectionName { get; set; }
        public string DataBaseName { get; set; }
    }
}