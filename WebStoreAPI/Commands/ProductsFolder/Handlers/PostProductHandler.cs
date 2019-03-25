using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.ProductsFolder.Handlers
{
    public class PostProductHandler : Command
    {
        public PostProductHandler(WebStoreContext context) : base(context)
        {
        }

        public override void Execute(Product obj)
        {
            Context.Products.Add(obj);
        }
    }
}
