using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.ProductsFolder.Handlers
{
    public class DeleteProductHandler : Command<Product>
    {
        public DeleteProductHandler(WebStoreContext context) : base(context)
        {
        }

        public override void Execute(Product product)
        {
            Context.Products.Remove(product);
            Context.SaveChanges();
        }
    }
}