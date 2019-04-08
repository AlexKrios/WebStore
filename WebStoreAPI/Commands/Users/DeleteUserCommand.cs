using MediatR;

namespace WebStoreAPI.Commands.Users
{
    public class DeleteUserCommand : IRequest<DeleteUserCommand>
    {
        public int Id { get; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
