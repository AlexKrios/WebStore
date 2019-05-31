using AutoMapper;
using CQS.Commands.Payments;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Payments
{
    public class CreatePaymentHandler : IRequestHandler<CreatePaymentCommand, Payment>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePaymentHandler> _logger;

        public CreatePaymentHandler(WebStoreContext context, IMapper mapper, ILogger<CreatePaymentHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Payment> Handle(CreatePaymentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var payment = _mapper.Map<Payment>(command);

                await _context.Payments.AddAsync(payment, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return payment;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"CREATE PAYMENT, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
