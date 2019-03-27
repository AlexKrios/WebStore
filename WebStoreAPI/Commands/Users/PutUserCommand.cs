using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Users
{
    //Put request command for user
    public class PutUserCommand : IRequest<User>
    {
        public User User { get; }

        public PutUserCommand(User user)
        {
            User = user;
        }
    }
}
