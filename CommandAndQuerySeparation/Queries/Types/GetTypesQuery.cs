using System.Collections.Generic;
using LinqSpecs;
using MediatR;
using Type = DataLibrary.Entities.Type;

namespace CQS.Queries.Types
{
    public class GetTypesQuery : IRequest<IEnumerable<Type>>
    {
        public Specification<Type> Specification { get; set; }
    }
}
