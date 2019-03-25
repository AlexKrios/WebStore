using System.Linq;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Products
{
    //Query for output single product
    public class GetProductHandler : Query<Product>
    {
        public GetProductHandler(WebStoreContext context) : base(context)
        {
        }

        public override Product Execute(int id)
        {
            var product = Context.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }
    }
}
