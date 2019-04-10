using MediatR;

namespace CommandAndQuerySeparation.Commands.Users
{
    public class DeleteUserCommand : IRequest<DeleteUserCommand>
    {
        public int Id { get; set; }
    }
}
