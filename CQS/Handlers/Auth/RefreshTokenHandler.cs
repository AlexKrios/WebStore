using System;
using System.Threading;
using System.Threading.Tasks;
using CQS.Commands.Auth;
using CQS.Exceptions;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.Auth
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, RefreshToken>
    {
        private readonly WebStoreContext _context;

        public RefreshTokenHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<RefreshToken> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var refreshToken = await _context.RefreshTokens
                    .FirstOrDefaultAsync(x => x.Token == command.Token, cancellationToken);

                if (refreshToken == null)
                    throw new NotFoundException();

                if (refreshToken.Expires < DateTime.Now)
                    throw new ExpiredTokenException();

                return refreshToken;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
