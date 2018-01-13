using AwasthiSM.Domain.Entities.Sample;
using System;
using System.Linq;

namespace AwasthiSM.Domain.Query
{
    public interface IQuery
    {
        IQueryable<Customer> GetCustomers();
        Customer GetCustomerById(Guid Id);
    }
}
