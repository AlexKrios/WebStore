using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Manufacturers
{
    public class GetAllManufacturersQuery : IRequest<IEnumerable<Manufacturer>>
    {
    }
}
