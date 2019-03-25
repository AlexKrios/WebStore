using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.UsersFolder.Handlers
{
    public class SaveUserHandler : Command
    {
        public SaveUserHandler(WebStoreContext context) : base(context)
        {
        }

        public override void Execute()
        {
            Context.SaveChanges();
        }
    }
}
