using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Users
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}
