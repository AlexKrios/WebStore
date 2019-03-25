using System.Collections.Generic;
using System.Linq;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.ProductsFolder.Handlers
{
    public class GetGroupProductsHandler : Query<IEnumerable<Product>>
    {
        public GetGroupProductsHandler(WebStoreContext context) : base(context)
        {
        }

        public override IEnumerable<Product> Execute(string type)
        {
            IEnumerable<Product> products = Context.Products.Where(x => x.Type == type);
            return products.ToList();
        }
    }
}
