using AutoMapper;
using CQS.Commands.Countries;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Countries
{
    public class UpdateCountryHandler : IRequestHandler<UpdateCountryCommand, Country>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCountryHandler> _logger;

        public UpdateCountryHandler(WebStoreContext context, IMapper mapper, ILogger<UpdateCountryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Country> Handle(UpdateCountryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Countries.Any(x => x.Id == command.Id)) return null;

                var country = _mapper.Map<Country>(command);

                _context.Countries.Update(country);
                await _context.SaveChangesAsync(cancellationToken);
                return country;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"UPDATE COUNTRY, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}