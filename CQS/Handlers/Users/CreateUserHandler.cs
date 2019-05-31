using AutoMapper;
using CQS.Commands.Users;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateUserHandler> _logger;

        public CreateUserHandler(WebStoreContext context, IMapper mapper, ILogger<CreateUserHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = _mapper.Map<User>(command);

                await _context.Users.AddAsync(user, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return user;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"CREATE USER, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
