using AwasthiSM.Shared.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwasthiSM.CommandProcessor.Command
{
    public interface IValidationHandler<in TCommand> where TCommand : ICommand
    {
        Task<IEnumerable<ValidationResult>>  Validate(TCommand command);
    }
}
