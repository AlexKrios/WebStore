using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Types
{
    public class GetTypeQuery : IRequest<Type>
    {
        public int Id { get; set; }
    }
}
