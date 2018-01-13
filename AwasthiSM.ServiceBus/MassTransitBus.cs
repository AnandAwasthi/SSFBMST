

using MassTransit;

namespace AwasthiSM.ServiceBus
{
    public class MassTransitBus : ITransitBus
    {

        private IBusControl _busControl;
        
        public MassTransitBus(IBusControl busControl)
        {
            _busControl = busControl;
            
        }
        IBusControl ITransitBus.GetBus => _busControl;

      

    }
}
