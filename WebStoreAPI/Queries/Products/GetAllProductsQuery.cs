using System.Collections.Generic;
using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Products
{
    //Get all products command
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
