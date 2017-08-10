using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AwasthiSM.CommandProcessor;
using AwasthiSM.Core.Common;
using System.Threading.Tasks;

namespace AwasthiSM.CommandProcessor.Command
{
    public interface IValidationHandler<in TCommand> where TCommand : ICommand
    {
        Task<IEnumerable<ValidationResult>>  Validate(TCommand command);
    }
}
