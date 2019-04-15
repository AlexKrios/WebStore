using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Users
{
    public class DeleteUserCommand : IRequest<User>
    {
        public int Id { get; set; }
    }
}
