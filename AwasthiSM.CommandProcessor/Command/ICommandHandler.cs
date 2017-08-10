using System.Threading.Tasks;

namespace AwasthiSM.CommandProcessor.Command
{
    public interface ICommandHandler<in TCommand> where TCommand: ICommand
    {
        Task<ICommandResult> Execute(TCommand command);
    }
}

