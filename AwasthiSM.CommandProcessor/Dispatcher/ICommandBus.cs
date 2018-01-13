using AwasthiSM.CommandProcessor.Command;
using AwasthiSM.Shared.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwasthiSM.CommandProcessor.Dispatcher
{
    public interface ICommandBus
    {
        Task<ICommandResult> Submit<TCommand>(TCommand command) where TCommand: ICommand;
        Task<IEnumerable<ValidationResult>> Validate<TCommand>(TCommand command) where TCommand : ICommand;
    }
}

