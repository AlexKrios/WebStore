using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Auth
{
    public class RefreshTokenCommand : IRequest<RefreshToken>
    {
        public string Token { get; set; }
    }
}