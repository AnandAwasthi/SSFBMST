using AwasthiSM.ServiceBus;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;
namespace AwasthiSM.Data.Persistence
{
    public static class Reposistory
    {
        public static async Task<bool> InsertOneAsync<T>(this IMongoCollection<T> mongoCollection, ITransitBus transitBus, T command) where T : class
        {
            bool flag = false;
            try
            {
                await mongoCollection.InsertOneAsync(command)
                    .ContinueWith(async (t) =>
                    {
                        await transitBus.GetBus.Publish<T>(command);
                    });
                flag = true;
            }
            catch (Exception)
            {

                throw;
            }
            return flag;
        }


    }
}
