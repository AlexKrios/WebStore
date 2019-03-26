using System.Collections.Generic;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Products
{
    //Query for output all products in table
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
