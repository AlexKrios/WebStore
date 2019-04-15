using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Users
{
    public class DeleteUserCommand : IRequest<User>
    {
        public int Id { get; set; }
    }
}
