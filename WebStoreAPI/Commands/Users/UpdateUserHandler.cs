using AutoMapper;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;

namespace WebStoreAPI.Commands.Users
{
    //Put request handler for user
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateUserHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateUserCommand> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Users.Any(x => x.Id == command.Id)) return null;

                _context.Users.Update(_mapper.Map<User>(command));
                await _context.SaveChangesAsync(cancellationToken);
                return command;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}