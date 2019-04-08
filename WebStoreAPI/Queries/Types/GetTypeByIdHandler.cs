using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Queries.Types
{
    public class GetTypeByIdHandler : IRequestHandler<GetTypeByIdQuery, Type>
    {
        private readonly WebStoreContext _context;

        public GetTypeByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Type> Handle(GetTypeByIdQuery command, CancellationToken cancellationToken)
        {
            return await _context.Types.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);
        }
    }
}
