using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Manufacturers
{
    public class UpdateManufacturerHandler : IRequestHandler<UpdateManufacturerCommand, Manufacturer>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateManufacturerHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Manufacturer> Handle(UpdateManufacturerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Manufacturers.Any(x => x.Id == command.Id)) return null;

                var manufacturer = _mapper.Map<Manufacturer>(command);

                _context.Manufacturers.Update(manufacturer);
                await _context.SaveChangesAsync(cancellationToken);
                return manufacturer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}