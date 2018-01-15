using AwasthiSM.ServiceBus;
using System.Threading.Tasks;

namespace AwasthiSM.Data.Persistence
{
    public static class TransitBus
    {
        public static async Task Publish<T>(this ITransitBus transitBus, T command) where T : class
        {
            await transitBus.GetBus.Publish<T>(command).ConfigureAwait(false);
        }
    }
}
