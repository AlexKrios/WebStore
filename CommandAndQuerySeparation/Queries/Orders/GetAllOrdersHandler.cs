using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Orders
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<GetAllOrdersQuery>>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetAllOrdersHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllOrdersQuery>> Handle(GetAllOrdersQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var orders = await _context.Orders.ToListAsync(cancellationToken);
                var result = _mapper.Map<IEnumerable<Order>, IEnumerable<GetAllOrdersQuery>>(orders);
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