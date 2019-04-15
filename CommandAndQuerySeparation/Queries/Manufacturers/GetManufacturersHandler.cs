﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Manufacturers
{
    public class GetManufacturersHandler : IRequestHandler<GetManufacturersQuery, IEnumerable<Manufacturer>>
    {
        private readonly WebStoreContext _context;

        public GetManufacturersHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Manufacturer>> Handle(GetManufacturersQuery query, CancellationToken cancellationToken)
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