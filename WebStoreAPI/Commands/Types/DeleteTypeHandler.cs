using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Commands.Types
{
    public class DeleteTypeHandler : IRequestHandler<DeleteTypeCommand, DeleteTypeCommand>
    {
        private readonly WebStoreContext _context;

        public DeleteTypeHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<DeleteTypeCommand> Handle(DeleteTypeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var type = await _context.Types.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (type == null) return null;

                _context.Types.Remove(type);
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
