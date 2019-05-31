using CQS.Queries.Users;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Users
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetUsersHandler> _logger;

        public GetUsersHandler(WebStoreContext context, ILogger<GetUsersHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<User>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Users.Where(query.Specification).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET USERS, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}