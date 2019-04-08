﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Queries.Products
{
    //Get group of products handler
    public class GetProductsByTypeHandler : IRequestHandler<GetProductsByTypeQuery, IEnumerable<Product>>
    {
        private readonly WebStoreContext _context;

        public GetProductsByTypeHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsByTypeQuery command, CancellationToken cancellationToken)
        {
            return await _context.Products.Where(x => Equals(x.Name, command.Type)).ToListAsync(cancellationToken);
        }
    }
}
