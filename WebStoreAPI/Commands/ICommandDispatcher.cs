namespace WebStoreAPI.Commands
{
    public interface ICommandDispatcher
    {
        void Execute<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}
