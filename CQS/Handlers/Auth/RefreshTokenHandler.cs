using System;
using System.Threading;
using System.Threading.Tasks;
using CQS.Commands.Auth;
using CQS.Exceptions;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CQS.Handlers.Auth
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, RefreshToken>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<RefreshTokenHandler> _logger;

        public RefreshTokenHandler(WebStoreContext context, ILogger<RefreshTokenHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<RefreshToken> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var refreshToken = await _context.RefreshTokens
                    .FirstOrDefaultAsync(x => x.Token == command.Token, cancellationToken);

                if (refreshToken == null)
                    throw new NotFoundException("REFRESH TOKEN, HANDLER - Not found");

                if (refreshToken.Expires < DateTime.Now)
                    throw new ExpiredTokenException("REFRESH TOKEN, HANDLER - Expired token");

                return refreshToken;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"REFRESH TOKEN, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
