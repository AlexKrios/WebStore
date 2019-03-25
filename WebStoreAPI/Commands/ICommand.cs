using WebStoreAPI.Models;

namespace WebStoreAPI.Commands
{
    public interface ICommand<in T> where T : IBaseEntity
    {
        void Execute(T product);
    }
}
