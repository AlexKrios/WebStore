using AutoMapper;
using CQS.Commands.UserRoles;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.UserRoles
{
    public class UpdateUserRoleHandler : IRequestHandler<UpdateUserRoleCommand, UserRole>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateUserRoleHandler> _logger;

        public UpdateUserRoleHandler(WebStoreContext context, IMapper mapper, ILogger<UpdateUserRoleHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserRole> Handle(UpdateUserRoleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.UserRoles.Any(x => x.Id == command.Id)) return null;

                var userRole = _mapper.Map<UserRole>(command);

                _context.UserRoles.Update(userRole);
                await _context.SaveChangesAsync(cancellationToken);
                return userRole;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"UPDATE USERROLE, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}