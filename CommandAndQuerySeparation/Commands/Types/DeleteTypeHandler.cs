using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Type = DataLibrary.Entities.Type;

namespace CommandAndQuerySeparation.Commands.Types
{
    public class DeleteTypeHandler : IRequestHandler<DeleteTypeCommand, Type>
    {
        private readonly WebStoreContext _context;

        public DeleteTypeHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Type> Handle(DeleteTypeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var type = await _context.Types.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (type == null) return null;

                _context.Types.Remove(type);
                await _context.SaveChangesAsync(cancellationToken);
                return type;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
