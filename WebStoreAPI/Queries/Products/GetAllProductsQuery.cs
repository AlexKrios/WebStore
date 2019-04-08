using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Products
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
