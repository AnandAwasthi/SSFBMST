using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwasthiSM.Mongo.DatabaseFactory
{
    public interface IDbContext
    {
        IMongoDatabase Get();
        IMongoCollection<T> GetCollection<T>(string collectionName);
    }
}
