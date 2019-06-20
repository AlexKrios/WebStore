using System.Collections.Generic;
using DataLibrary.Entities;
using LinqSpecs;
using MediatR;

namespace CQS.Queries.Cities
{
    public class GetCitiesQuery : IRequest<IEnumerable<City>>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public Specification<City> Specification { get; set; }
    }
}