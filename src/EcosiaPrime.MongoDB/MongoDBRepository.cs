using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace EcosiaPrime.MongoDB
{
    public class MongoDBRepository
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDBRepository()
        {
            var client = new MongoClient();
            _mongoDatabase = client.GetDatabase("dd");
        }
    }
}
