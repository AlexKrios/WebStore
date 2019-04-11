using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Manufacturers
{
    public class GetAllManufacturersQuery : IRequest<IEnumerable<Manufacturer>>
    {

    }
}
