using AutoMapper;
using CQS.Commands.Payments;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Payments
{
    public class UpdatePaymentHandler : IRequestHandler<UpdatePaymentCommand, Payment>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdatePaymentHandler> _logger;

        public UpdatePaymentHandler(WebStoreContext context, IMapper mapper, ILogger<UpdatePaymentHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Payment> Handle(UpdatePaymentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Payments.Any(x => x.Id == command.Id)) return null;

                var payment = _mapper.Map<Payment>(command);

                _context.Payments.Update(payment);
                await _context.SaveChangesAsync(cancellationToken);
                return payment;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"UPDATE PAYMENT, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}