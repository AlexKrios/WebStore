using WebStoreAPI.Models;

namespace WebStoreAPI.Commands
{
    public abstract class Command<T> : ICommand<T> where T : IBaseEntity
    {
        public readonly WebStoreContext Context;

        protected Command(WebStoreContext context)
        {
            Context = context;
        }

        public virtual void Execute()
        {
        }

        public virtual void Execute(T product)
        {
        }
    }
}
