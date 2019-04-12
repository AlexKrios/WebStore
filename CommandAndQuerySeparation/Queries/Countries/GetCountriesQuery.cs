using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Countries
{
    public class GetCountriesQuery : IRequest<IEnumerable<Country>>
    {

    }
}