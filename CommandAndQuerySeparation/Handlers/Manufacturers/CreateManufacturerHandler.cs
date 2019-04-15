using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Manufacturers;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.Manufacturers
{
    public class CreateManufacturerHandler : IRequestHandler<CreateManufacturerCommand, Manufacturer>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateManufacturerHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Manufacturer> Handle(CreateManufacturerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var manufacturer = _mapper.Map<Manufacturer>(command);

                await _context.Manufacturers.AddAsync(manufacturer, cancellationToken);
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
