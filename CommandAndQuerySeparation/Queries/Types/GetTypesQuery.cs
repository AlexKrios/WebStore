using System.Collections.Generic;
using MediatR;
using Type = DataLibrary.Entities.Type;

namespace CQS.Queries.Types
{
    public class GetTypesQuery : IRequest<IEnumerable<Type>>
    {
    }
}
