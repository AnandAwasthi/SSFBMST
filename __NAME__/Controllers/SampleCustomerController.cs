using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AwasthiSM.CommandProcessor.Dispatcher;
using AwasthiSM.Domain.Query;

using AwasthiSM.Domain.Command;
using AwasthiSM.Domain.Entities.Sample;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace __NAME__.Controllers
{
    [Route("api/[controller]")]
    public class SampleCustomerController : Controller
    {

        private readonly ICommandBus _commandBus;
        private readonly IQuery _query;
        public SampleCustomerController(ICommandBus commandBus, IQuery query)
        {
            this._commandBus = commandBus;
            this._query = query;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var customers = _query.GetCustomers();
            return customers.ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Customer Get(Guid id)
        {
             return _query.GetCustomerById(id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]Customer customer)
        {
            var customerCommand = new CreateOrUpdateCustomerCommand(customer.CustomerId, customer.Name);
            await _commandBus.Submit(customerCommand);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody]Customer customer)
        {
            var customerCommand = new CreateOrUpdateCustomerCommand(id, customer.Name);
            await _commandBus.Submit(customerCommand);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
