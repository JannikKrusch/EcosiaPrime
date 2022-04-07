using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosiaPrime.MongoDB
{
    public class MongoDBService : IMongoDBService
    {
        private readonly IMongoDBRepository _mongoDBRepository;
        public MongoDBService(IMongoDBRepository mongoDBRepository)
        {
            _mongoDBRepository = mongoDBRepository;
        }


    }
}
