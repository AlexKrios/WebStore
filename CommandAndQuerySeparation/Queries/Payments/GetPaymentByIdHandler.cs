using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Payments
{
    public class GetPaymentByIdHandler : IRequestHandler<GetPaymentByIdQuery, GetPaymentByIdQuery>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetPaymentByIdHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetPaymentByIdQuery> Handle(GetPaymentByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var payment = await _context.Payments.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
                var result = _mapper.Map<Payment, GetPaymentByIdQuery>(payment);
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
