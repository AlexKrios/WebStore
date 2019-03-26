using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Delete command for product model
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