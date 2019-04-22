using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;
using Specification.Requests.Manufacturers;
using Specification.Specification.Filters;

namespace CQS.Queries.Manufacturers
{
    public class GetManufacturersQuery : IRequest<IEnumerable<Manufacturer>>
    {
        public GetManufacturersFilter Filter { get; set; }

        public GetManufacturersQuery(GetManufacturersRequest filter)
        {
            Filter = new GetManufacturersFilter(filter);
        }
    }
}
