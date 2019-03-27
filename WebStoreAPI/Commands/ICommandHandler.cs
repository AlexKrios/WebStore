namespace WebStoreAPI.Commands
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommandTag
    {
        void Execute(TCommand command);
    }
}