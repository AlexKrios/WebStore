using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Cities
{
    public class GetCitiesQuery : IRequest<IEnumerable<City>>
    {

    }
}