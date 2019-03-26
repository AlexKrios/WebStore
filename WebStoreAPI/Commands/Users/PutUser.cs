using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    public class PutUser<T> : ICommand<T> where T : IBaseEntity
    {
        public virtual void Execute(T product)
        {
        }
    }
}
