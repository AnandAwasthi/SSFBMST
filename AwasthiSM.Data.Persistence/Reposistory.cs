using AwasthiSM.ServiceBus;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;
namespace AwasthiSM.Data.Persistence
{
    public static class Reposistory
    {
        public static async Task<bool> InsertOneAsync<T>(this IMongoCollection<T> mongoCollection, ITransitBus transitBus, T command) where T : class
        {
            bool flag = false;

            await mongoCollection.InsertOneAsync(command)
                .ContinueWith(async (t) =>
                {
                    if (transitBus != null)
                    {
                        await transitBus.Publish<T>(command);
                    }
                });
            flag = true;


            return flag;
        }
        public static async Task<bool> InsertOrReplaceOneAsync<T>(this IMongoCollection<T> mongoCollection, ITransitBus transitBus, T command, Expression<Func<T, bool>> predicate) where T : class
        {
            bool flag = false;


            if ((mongoCollection.AsQueryable().Where(predicate).Any()))
            {
                await mongoCollection.ReplaceOneAsync(predicate, command);
            }
            else
            {
                await mongoCollection.InsertOneAsync(command);
            }
            if (transitBus != null)
            {
                await transitBus.Publish<T>(command);
            }


            return flag;
        }

    }
}
