using System.Threading.Tasks;

namespace WebStoreAPI.Commands
{
    public interface ICommandDispatcher
    {
        Task Execute<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}
