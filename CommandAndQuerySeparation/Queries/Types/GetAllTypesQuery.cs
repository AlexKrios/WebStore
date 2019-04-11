using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Types
{
    public class GetAllTypesQuery : IRequest<IEnumerable<Type>>
    {

    }
}
