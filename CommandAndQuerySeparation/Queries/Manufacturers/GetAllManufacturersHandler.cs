using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Manufacturers
{
    public class GetAllManufacturersHandler : IRequestHandler<GetAllManufacturersQuery, IEnumerable<Manufacturer>>
    {
        private readonly WebStoreContext _context;

        public GetAllManufacturersHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Manufacturer>> Handle(GetAllManufacturersQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Manufacturers.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}