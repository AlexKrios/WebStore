using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Payments
{
    public class GetAllPaymentsHandler : IRequestHandler<GetAllPaymentsQuery, IEnumerable<GetAllPaymentsQuery>>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetAllPaymentsHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllPaymentsQuery>> Handle(GetAllPaymentsQuery query, CancellationToken cancellationToken)
        {
            var payments = await _context.Payments.ToListAsync(cancellationToken);
            var result = _mapper.Map<IEnumerable<Payment>, IEnumerable<GetAllPaymentsQuery>>(payments);
            return result;
        }
    }
}