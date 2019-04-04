using MediatR;

namespace WebStoreAPI.Commands.Users
{
    //Put request command for user
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public int Age { get; set; }
    }
}
