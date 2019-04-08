using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Products
{
    //Get all products command
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
