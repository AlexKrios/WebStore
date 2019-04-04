using MediatR;

namespace WebStoreAPI.Commands.Users
{
    //Delete request command for user
    public class DeleteUserCommand : IRequest<DeleteUserCommand>
    {
        public int Id { get; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
