using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.OrderItems
{
    public class GetAllOrderItemsHandler : IRequestHandler<GetAllOrderItemsQuery, IEnumerable<GetAllOrderItemsQuery>>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetAllOrderItemsHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllOrderItemsQuery>> Handle(GetAllOrderItemsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var orderItems = await _context.OrderItems.ToListAsync(cancellationToken);
                var result = _mapper.Map<IEnumerable<OrderItem>, IEnumerable<GetAllOrderItemsQuery>>(orderItems);
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