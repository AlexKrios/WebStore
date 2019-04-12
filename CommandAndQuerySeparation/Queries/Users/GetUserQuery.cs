using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Users
{
    public class GetUserQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}
