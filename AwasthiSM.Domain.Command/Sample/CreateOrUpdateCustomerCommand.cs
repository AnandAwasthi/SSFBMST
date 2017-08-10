using AwasthiSM.CommandProcessor.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwasthiSM.Domain.Command
{
    public class CreateOrUpdateCustomerCommand : ICommand
    {
        public CreateOrUpdateCustomerCommand(Guid id, string name)
        {
            CustomerId = id;
            Name = name;
        }
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        
    }
}
