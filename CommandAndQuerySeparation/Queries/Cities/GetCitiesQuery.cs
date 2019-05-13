using System.Collections.Generic;
using DataLibrary.Entities;
using LinqSpecs;
using MediatR;

namespace CQS.Queries.Cities
{
    public class GetCitiesQuery : IRequest<IEnumerable<City>>
    {
        public Specification<City> Specification { get; set; }
    }
}