using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Delete request command for user
    public class DeleteUserCommand : ICommand
    {
        public User User { get; }

        public DeleteUserCommand(User user)
        {
            User = user;
        }
    }
}
