using System.Threading.Tasks;
using SimpleInjector;

namespace WebStoreAPI.Commands
{
    //Command dispatcher for all model
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly Container _container;

        public CommandDispatcher(Container container)
        {
            _container = container;
        }

        public async Task Execute<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var handler = _container.GetInstance<ICommandHandler<TCommand>>();
            await handler.Execute(command);
        }
    }
}
