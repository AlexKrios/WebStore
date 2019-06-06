using CQS.Commands.Auth;
using CQS.Exceptions;
using CQS.Utils;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Auth
{
    public class CreateTokenHandler : IRequestHandler<CreateTokenCommand, RefreshToken>
    {
        private readonly IConfiguration _config;
        private readonly WebStoreContext _context;
        private readonly AuthPasswordHash _hash;

        public CreateTokenHandler(IConfiguration config, WebStoreContext context, AuthPasswordHash hash)
        {
            _config = config;
            _context = context;
            _hash = hash;
        }

        public async Task<RefreshToken> Handle(CreateTokenCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Login.Equals(command.Login),
                    cancellationToken);

                if (user == null)
                    throw new NotFoundException("CREATE TOKEN, HANDLER - NOT FOUND");

                var commandPassHash = _hash.PasswordHash(command.Password);
                if (!user.PasswordHash.Equals(commandPassHash))
                    throw new UnauthorizedException("CREATE TOKEN, HANDLER - UNAUTHORIZED");

                var refreshToken =
                    await _context.RefreshTokens.FirstOrDefaultAsync(x => x.UserId == user.Id,
                        cancellationToken);

                if (refreshToken != null)
                {
                    _context.RefreshTokens.Remove(refreshToken);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                var newRefreshToken = new RefreshToken
                {
                    UserId = user.Id,
                    Token = Guid.NewGuid().ToString(),
                    Issued = DateTime.Now,
                    Expires = DateTime.Now.AddMinutes(double.Parse(_config["Jwt:ExpireMinutes"]))
                };

                _context.RefreshTokens.Add(newRefreshToken);
                await _context.SaveChangesAsync(cancellationToken);

                return newRefreshToken;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
