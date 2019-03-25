using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.ProductsFolder.Handlers
{
    public class PutProductHandler : Command
    {
        public PutProductHandler(WebStoreContext context) : base(context)
        {
        }

        public override void Execute(Product obj)
        {
            Context.Update(obj);
        }
    }
}
