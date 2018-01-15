using AwasthiSM.CommandProcessor.Command;
using AwasthiSM.Data.Persistence;
using AwasthiSM.Domain.Command;
using AwasthiSM.Mongo.DatabaseFactory;
using AwasthiSM.ServiceBus;
using System.Threading.Tasks;

namespace AwasthiSM.Domain.Handler.Sample
{
    public class CreateOrUpdateApplicationRegistryHandler : ICommandHandler<CreateOrUpdateCustomerCommand>
    {
        private readonly IDbContext _dbContext;
        private readonly ITransitBus _transitBus;
        public CreateOrUpdateApplicationRegistryHandler(IDbContext dbContext, ITransitBus transitBus)
        {
            _dbContext = dbContext;
            _transitBus = transitBus;
        }

        public async Task<ICommandResult> Execute(CreateOrUpdateCustomerCommand command)
        {
            var collection = _dbContext.GetCollection<CreateOrUpdateCustomerCommand>("SampleCustomer");
            await collection.InsertOneAsync(_transitBus,command);
            return new CommandResult(true);
        }
    }
}
