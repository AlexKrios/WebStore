using WebStoreAPI.Models;

namespace WebStoreAPI.Commands
{
    public interface ICommandDispatcher
    {
        /*void Dispatch<TCommand, T>(T product)
            where TCommand : class, ICommand<T>
            where T : IBaseEntity;*/

        void Execute<TCommand, TCommandHandler>(TCommand command)
            where TCommand : class, ICommandTag;
    }
}
