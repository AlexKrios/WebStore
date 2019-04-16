using System;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Types;
using DataLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Type = DataLibrary.Entities.Type;

namespace CQS.Handlers.Types
{
    public class GetTypeHandler : IRequestHandler<GetTypeQuery, Type>
    {
        private readonly WebStoreContext _context;

        public GetTypeHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Type> Handle(GetTypeQuery query, CancellationToken cancellationToken)
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
