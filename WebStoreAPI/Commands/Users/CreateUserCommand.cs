using MediatR;

namespace WebStoreAPI.Commands.Users
{
    //Post request command for user
    public class CreateUserCommand : IRequest<CreateUserCommand>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public int Age { get; set; }
    }
}
