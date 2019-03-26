using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    public class PostUser<T> : ICommand<T> where T : IBaseEntity
    {
        public virtual void Execute(T product)
        {
        }
    }
}
