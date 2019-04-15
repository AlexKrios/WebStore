using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Products
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
        
    }
}
