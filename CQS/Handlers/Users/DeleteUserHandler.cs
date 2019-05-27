using CQS.Commands.Users;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Users
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, User>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<DeleteUserHandler> _logger;

        public DeleteUserHandler(WebStoreContext context, ILogger<DeleteUserHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<User> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (user == null) return null;

                _context.Users.Remove(user);
                await _context.SaveChangesAsync(cancellationToken);
                return user;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"DELETE USER, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
