using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Auth
{
    public class CreateTokenCommand : IRequest<RefreshToken>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
