using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Countries;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.Countries
{
    public class UpdateCountryHandler : IRequestHandler<UpdateCountryCommand, Country>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateCountryHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                Console.WriteLine(e);
                throw;
            }
        }
    }
}