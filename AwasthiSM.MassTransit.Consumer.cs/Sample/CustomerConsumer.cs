using AwasthiSM.CommandProcessor.Dispatcher;
using AwasthiSM.Domain.Command;
using AwasthiSM.Domain.Entities.Sample;
using MassTransit;
using System.Threading.Tasks;

namespace AwasthiSM.MassTransit.Consumer
{
    public class CustomerConsumer :
         //IConsumer<CreateOrUpdateCustomerCommand>,
         IConsumer<CustomerRequest>
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

        public async Task Consume(ConsumeContext<CustomerRequest> context)
        {
            await context.RespondAsync(new CustomerResponse
            {
                CustomerId = context.Message.Id,
                CustomerName = context.Message.Name

            });
        }
    }



}
