using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Delete request handler for user
    public class DeleteUserHandler : ICommandHandler<DeleteUserCommand>
    {
        private readonly WebStoreContext _context;

        public DeleteUserHandler(WebStoreContext context)
        {
            _context = context;
        }

        public void Execute(DeleteUserCommand command)
        {
            _context.Users.Remove(command.Id);
            _context.SaveChanges();
        }
    }
}
