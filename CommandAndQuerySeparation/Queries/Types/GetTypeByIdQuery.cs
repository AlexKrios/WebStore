using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Types
{
    public class GetTypeByIdQuery : IRequest<Type>
    {
        public int Id { get; set; }
    }
}
