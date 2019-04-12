using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Users
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
    }
}
