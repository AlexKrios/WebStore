using System.Collections.Generic;
using DataLibrary.Entities;
using LinqSpecs;
using MediatR;

namespace CQS.Queries.Countries
{
    public class GetCountriesQuery : IRequest<IEnumerable<Country>>
    {
        public Specification<Country> Specification { get; set; }
    }
}