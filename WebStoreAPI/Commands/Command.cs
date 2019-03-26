using WebStoreAPI.Models;

namespace WebStoreAPI.Commands
{
    //Parent class for command
    public abstract class Command<T> : ICommand<T> where T : IBaseEntity
    {
        protected readonly WebStoreContext Context;

        protected Command(WebStoreContext context)
        {
            Context = context;
        }

        public virtual void Execute(T product)
        {
        }
    }
}
