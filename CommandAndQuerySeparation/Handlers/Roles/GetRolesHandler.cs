﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Roles;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.Roles
{
    public class GetRolesHandler : IRequestHandler<GetRolesQuery, IEnumerable<Role>>
    {
        private readonly WebStoreContext _context;

        public GetRolesHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> Handle(GetRolesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var result = _context.Roles.Where(o => query.Filter.NameEquals.IsSatisfiedBy(o));
                if (!result.Any())
                    return await _context.Roles.ToListAsync(cancellationToken);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}