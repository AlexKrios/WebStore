using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Type = DataLibrary.Entities.Type;

namespace CommandAndQuerySeparation.Queries.Types
{
    public class GetTypeByIdHandler : IRequestHandler<GetTypeByIdQuery, Type>
    {
        private readonly WebStoreContext _context;

        public GetTypeByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Type> Handle(GetTypeByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Types.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
