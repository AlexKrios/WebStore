using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.OrderItems
{
    public class GetOrderItemsByIdHandler : IRequestHandler<GetOrderItemsByIdQuery, GetOrderItemsByIdQuery>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetOrderItemsByIdHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetOrderItemsByIdQuery> Handle(GetOrderItemsByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var orderItem = await _context.OrderItems.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
                var result = _mapper.Map<OrderItem, GetOrderItemsByIdQuery>(orderItem);
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
