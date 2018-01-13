using AwasthiSM.Domain.Entities.Sample;
using AwasthiSM.Mongo.DatabaseFactory;
using MongoDB.Driver;
using System;
using System.Linq;

namespace AwasthiSM.Domain.Query.ApiManagment
{
    public class CustomerQuery : IQuery

    {
        private IDbContext _dbContext;
        public CustomerQuery(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Customer> GetCustomers()
        {
            var customerCollection = _dbContext.GetCollection<Customer>("SampleCustomer").AsQueryable();

            var customerDetail = from arc in customerCollection
                                 select new Customer { CustomerId = arc.CustomerId, Name = arc.Name };
            return customerDetail;
        }
        public Customer GetCustomerById(Guid Id)
        {
            var customerDetail = from arc in GetCustomers()
                                 where arc.CustomerId == Id
                                 select new Customer { CustomerId = arc.CustomerId, Name = arc.Name};
            return customerDetail.SingleOrDefault();
        }
    }
}
