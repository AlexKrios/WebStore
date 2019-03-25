using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.UsersFolder.Handlers
{
    public class PostUserHandler : Command
    {
        public PostUserHandler(WebStoreContext context) : base(context)
        {
        }

        /*public override void Execute<T>(User obj)
        {
            _context.Users.Add(obj);
        }*/
    }
}
