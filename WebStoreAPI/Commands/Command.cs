using WebStoreAPI.Models;

namespace WebStoreAPI.Commands
{
    public abstract class Command<T> : ICommand<T> where T : IBaseEntity
    {
        public abstract void Execute(T product);
    }
}
