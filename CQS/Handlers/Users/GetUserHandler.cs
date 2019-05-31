using CQS.Queries.Users;
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
    public class GetUserHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetUserHandler> _logger;

        public GetUserHandler(WebStoreContext context, ILogger<GetUserHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<User> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET USER, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
