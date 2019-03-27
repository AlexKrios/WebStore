using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Post request handler for user
    public class PostUserHandler : ICommandHandler<PostUserCommand>
    {
        private readonly WebStoreContext _context;

        public PostUserHandler(WebStoreContext context)
        {
            _context = context;
        }

        public void Execute(PostUserCommand command)
        {
            _context.Users.Add(command.Id);
            _context.SaveChanges();
        }
    }
}
