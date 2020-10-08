using System.Threading.Tasks;

namespace CQRS.Interfaces
{
    public interface ICommandHandlerAsync<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
