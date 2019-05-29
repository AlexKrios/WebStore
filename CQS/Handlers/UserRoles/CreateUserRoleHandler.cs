using AutoMapper;
using CQS.Commands.UserRoles;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.UserRoles
{
    public class CreateUserRoleHandler : IRequestHandler<CreateUserRoleCommand, UserRole>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateUserRoleHandler> _logger;

        public CreateUserRoleHandler(WebStoreContext context, IMapper mapper, ILogger<CreateUserRoleHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserRole> Handle(CreateUserRoleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var userRole = _mapper.Map<UserRole>(command);

                await _context.UserRoles.AddAsync(userRole, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return userRole;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"CREATE USERROLES, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
