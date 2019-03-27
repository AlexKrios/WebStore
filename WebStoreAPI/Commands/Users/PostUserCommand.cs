using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Post request command for user
    public class PostUserCommand : IRequest<User>
    {
        public User User { get; }

        public PostUserCommand(User user)
        {
            User = user;
        }
    }
}
