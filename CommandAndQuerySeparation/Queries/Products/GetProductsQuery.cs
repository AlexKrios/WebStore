using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Products
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
        
    }
}
