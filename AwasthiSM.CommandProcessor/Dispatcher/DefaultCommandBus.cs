
using System.Collections.Generic;
using AwasthiSM.CommandProcessor.Command;
using System.Threading.Tasks;
using AwasthiSM.Shared.Common;
using AwasthiSM.Shared;

namespace AwasthiSM.CommandProcessor.Dispatcher
{
    public class DefaultCommandBus : ICommandBus
    {
        public async Task<ICommandResult> Submit<TCommand>(TCommand command) where TCommand: ICommand
        {    
            var handler = DependencyResolver.Current.GetService<ICommandHandler<TCommand>>();

            if (!((handler != null) && handler is ICommandHandler<TCommand>))
            {
                throw new CommandHandlerNotFoundException(typeof(TCommand));
            }  
            return await handler.Execute(command);
 
        }
        public async Task<IEnumerable<ValidationResult>> Validate<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = DependencyResolver.Current.GetService<IValidationHandler<TCommand>>();
            if (!((handler != null) && handler is IValidationHandler<TCommand>))
            {
                throw new ValidationHandlerNotFoundException(typeof(TCommand));
            }  
            return await handler.Validate(command);
        }
    }
}

