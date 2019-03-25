using SimpleInjector;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands
{
    //Command dispatcher
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly Container _container;
        public CommandDispatcher(Container container)
        {
            _container = container;
        }

        public void Dispatch<TCommand, T>(T product) 
            where TCommand : class, ICommand<T>
            where T : IBaseEntity
        {
            var handler = _container.GetInstance<TCommand>();
            handler.Execute(product);
        }
    }
}
