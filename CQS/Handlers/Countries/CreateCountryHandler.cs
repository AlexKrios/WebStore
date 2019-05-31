using AutoMapper;
using CQS.Commands.Countries;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Countries
{
    public class CreateCountryHandler : IRequestHandler<CreateCountryCommand, Country>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCountryHandler> _logger;

        public CreateCountryHandler(WebStoreContext context, IMapper mapper, ILogger<CreateCountryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Country> Handle(CreateCountryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var country = _mapper.Map<Country>(command);

                await _context.Countries.AddAsync(country, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return country;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"CREATE COUNTRY, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
