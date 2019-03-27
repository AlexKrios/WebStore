using SimpleInjector;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly Container _container;
        public CommandDispatcher(Container container)
        {
            _container = container;
        }

        /*public void Dispatch<TCommand, T>(T product) 
            where TCommand : class, ICommand<T>
            where T : IBaseEntity
        {
            var handler = _container.GetInstance<TCommand>();
            handler.Execute(product);
        }*/


        public void Execute<TCommand, TCommandHandler>(TCommand command)
            where TCommand : class, ICommandTag
        {
            var handler = _container.GetInstance<TCommand>();
            handler.Execute(command);
        }
    }
}
