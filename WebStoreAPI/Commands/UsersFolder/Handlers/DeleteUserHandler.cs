using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.UsersFolder.Handlers
{
    public class DeleteUserHandler : Command<User>
    {
        public DeleteUserHandler(WebStoreContext context) : base(context)
        {
        }

        public override void Execute(User user)
        {
            Context.Users.Remove(user);
            Context.SaveChanges();
        }
    }
}
