using System.ComponentModel.DataAnnotations;
using MediatR;

namespace WebStoreAPI.Commands.Users
{
    //Post request command for user
    public class CreateUserCommand : IRequest<CreateUserCommand>
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
