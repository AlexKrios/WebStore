using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Countries
{
    public class CreateCountryHandler : IRequestHandler<CreateCountryCommand, Country>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateCountryHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
