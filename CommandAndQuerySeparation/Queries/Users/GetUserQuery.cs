using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Users
{
    public class GetUserQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}
