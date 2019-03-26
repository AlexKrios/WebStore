using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Delete command for user model
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
