using System.Threading.Tasks;

namespace WebStoreAPI.Commands
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        Task Execute(TCommand command);
    }
}