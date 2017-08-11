using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AwasthiSM.Mongo.DatabaseFactory;
using AwasthiSM.CommandProcessor.Dispatcher;
using AwasthiSM.Domain.Query;
using MassTransit;

namespace DatabaseService.Controllers
{
   
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ICommandBus commandBus;
        private readonly IQuery query;
        public ValuesController(ICommandBus commandBus, IQuery query)
        {
            this.commandBus = commandBus;
            this.query = query;

        }

        // GET api/values
        [HttpGet]
        public  IEnumerable<string> Get()
        {

            //var command = new CreateOrUpdateRegistryCommand(Guid.NewGuid(), "TCustomerService", "fabric:/TempCustomerService");
            //commandBus.Submit(command);

            var appRegistrationCommand = new CreateOrUpdateApplicationRegistrationCommand(Guid.NewGuid(), "AuthService");
            commandBus.Submit(appRegistrationCommand);

            //var appregitryCommand = new CreateOrUpdateApplicationRegistryCommand(Guid.NewGuid(), new Guid("5d7801ca-113a-7d40-8e56-37e9a673c899"), new Guid("67b54afd-87b4-9742-9088-e871fee48cb5"));

            //commandBus.Submit(appregitryCommand);

            //var ok = query.GetApplicationRegistryDetailById(new Guid("c3e4433b-a153-4511-b7c0-8d357ec226d3"));
            //var dd = ok.ToList();

            return new string[] {};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async void Post([FromBody]string value)
        {
            var command = new CreateOrUpdateRegistryCommand(Guid.NewGuid(), "DatabaseService", "fabric:/AwasthiSM.DatabaseService");
            await commandBus.Submit(command);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class ConsumerCreateOrUpdateApplicationRegistrationCommand :
     IConsumer<CreateOrUpdateApplicationRegistrationCommand>
    {
        public async Task Consume(ConsumeContext<CreateOrUpdateApplicationRegistrationCommand> context)
        {
            await Console.Out.WriteLineAsync($"Updating customer: {context.Message.AppId}");

            // update the customer address
        }
    }
}
