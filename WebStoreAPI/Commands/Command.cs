using WebStoreAPI.Models;

namespace WebStoreAPI.Commands
{
    public abstract class Command : ICommand
    {
        public readonly WebStoreContext Context;

        public Command(WebStoreContext context)
        {
            Context = context;
        }

        public virtual void Execute()
        {
        }

        public virtual void Execute(Product product)
        {
        }
    }
}
