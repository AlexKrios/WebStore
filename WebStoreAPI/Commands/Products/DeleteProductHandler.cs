using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;

namespace WebStoreAPI.Commands.Products
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductCommand>
    {
        private readonly WebStoreContext _context;

        public DeleteProductHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<DeleteProductCommand> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (product == null) return null;

                _context.Products.Remove(product);
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