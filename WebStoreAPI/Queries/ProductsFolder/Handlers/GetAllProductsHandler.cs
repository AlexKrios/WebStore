using System.Collections.Generic;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.ProductsFolder.Handlers
{
    public class GetAllProductsHandler : Query<IEnumerable<Product>>
    {
        public GetAllProductsHandler(WebStoreContext context) : base(context)
        {
        }

        public override IEnumerable<Product> Execute()
        {
            return Context.Products;
        }
    }
}
