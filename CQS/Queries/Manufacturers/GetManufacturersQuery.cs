using System.Collections.Generic;
using DataLibrary.Entities;
using LinqSpecs;
using MediatR;

namespace CQS.Queries.Manufacturers
{
    public class GetManufacturersQuery : IRequest<IEnumerable<Manufacturer>>
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public Specification<Manufacturer> Specification { get; set; }
    }
}
