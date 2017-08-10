using AwasthiSM.CommandProcessor.Dispatcher;
using AwasthiSM.Domain.Command;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwasthiSM.MassTransit.Consumer
{
    public class CustomerConsumer : 
        IConsumer<CreateOrUpdateCustomerCommand>
    {
        private readonly ICommandBus _commandBus;
        public CustomerConsumer() { }

        public CustomerConsumer(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }
        public async Task Consume(ConsumeContext<CreateOrUpdateCustomerCommand> context)
        {
            await _commandBus.Submit(context.Message);
        }
    }
    

     
}
