using WebStoreAPI.Models;

namespace WebStoreAPI.Commands
{
    public interface ICommandDispatcher
    {
        void Dispatch<TCommand>() 
            where TCommand : class, ICommand;

        void Dispatch<TCommand>(Product product)
            where TCommand : class, ICommand;
    }
}
