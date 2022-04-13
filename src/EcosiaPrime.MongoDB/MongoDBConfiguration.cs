using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosiaPrime.MongoDB
{
    public class MongoDBConfiguration : IMongoDBConfiguration
    {
        public string DataBaseName { get; set; }
        public string CollectionName { get; set; }
    }
}