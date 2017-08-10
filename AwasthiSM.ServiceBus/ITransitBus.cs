using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwasthiSM.ServiceBus
{
    public interface ITransitBus
    {
      
        IBusControl GetBus { get;}
    }
}
