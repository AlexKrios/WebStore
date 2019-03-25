using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Change command for product model
    public class PutProductHandler : Command<Product>
    {
        public PutProductHandler(WebStoreContext context) : base(context)
        {
        }

        public override void Execute(Product obj)
        {
            Context.Update(obj);
            Context.SaveChanges();
        }
    }
}
