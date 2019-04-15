using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Manufacturers
{
    public class GetManufacturersQuery : IRequest<IEnumerable<Manufacturer>>
    {

    }
}
