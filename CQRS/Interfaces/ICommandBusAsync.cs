using System.Threading.Tasks;

namespace CQRS.Interfaces
{
    public interface ICommandBusAsync
    {
        Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
