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

        public void Dispatch<TCommand>()
            where TCommand : class, ICommand
        {
            var handler = _container.GetInstance<TCommand>();
            handler.Execute();
        }

        public void Dispatch<TCommand>(Product product) 
            where TCommand : class, ICommand
        {
            var handler = _container.GetInstance<TCommand>();
            handler.Execute(product);
        }
    }
}
