using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Types
{
    public class GetTypesQuery : IRequest<IEnumerable<Type>>
    {

    }
}
