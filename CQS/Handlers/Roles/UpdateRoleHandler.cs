using AutoMapper;
using CQS.Commands.Roles;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Roles
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, Role>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateRoleHandler> _logger;

        public UpdateRoleHandler(WebStoreContext context, IMapper mapper, ILogger<UpdateRoleHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Role> Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Roles.Any(x => x.Id == command.Id)) return null;

                var role = _mapper.Map<Role>(command);

                _context.Roles.Update(role);
                await _context.SaveChangesAsync(cancellationToken);
                return role;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"UPDATE ROLE, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}