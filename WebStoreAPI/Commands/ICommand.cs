using WebStoreAPI.Models;

namespace WebStoreAPI.Commands
{
    public interface ICommand
    {
        void Execute();
        void Execute(Product product);
    }
}
