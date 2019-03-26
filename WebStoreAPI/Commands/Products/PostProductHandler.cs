using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Insert command for product model
    public class PostProductHandler : Command<Product>
    {
        public PostProductHandler(WebStoreContext context) : base(context)
        {
        }

        public override void Execute(Product obj)
        {
            Context.Products.Add(obj);
            Context.SaveChanges();
        }
    }
}
