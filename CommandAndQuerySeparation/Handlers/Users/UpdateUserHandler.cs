using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Users;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.Users
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateUserHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Users.Any(x => x.Id == command.Id)) return null;

                var user = _mapper.Map<User>(command);

                _context.Users.Update(user);
                await _context.SaveChangesAsync(cancellationToken);
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}