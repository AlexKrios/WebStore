using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Cities
{
    public class GetCitiesQuery : IRequest<IEnumerable<City>>
    {

    }
}