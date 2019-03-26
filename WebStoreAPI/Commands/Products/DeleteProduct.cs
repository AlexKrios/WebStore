using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    public class DeleteProduct<T> : ICommand<T> where T : IBaseEntity
    {
        public virtual void Execute(T product)
        {
        }
    }
}