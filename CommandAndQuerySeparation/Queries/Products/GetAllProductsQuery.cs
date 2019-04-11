using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Products
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
        
    }
}
