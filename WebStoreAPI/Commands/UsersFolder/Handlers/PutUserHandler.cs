using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.UsersFolder.Handlers
{
    public class PutUserHandler : Command
    {
        public PutUserHandler(WebStoreContext context) : base(context)
        {
        }

        /*public override void Execute<T>(User obj)
        {
            _context.Update(obj);
        }*/
    }
}
