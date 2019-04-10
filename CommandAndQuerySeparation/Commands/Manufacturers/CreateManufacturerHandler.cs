using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Manufacturers
{
    public class CreateManufacturerHandler : IRequestHandler<CreateManufacturerCommand, CreateManufacturerCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateManufacturerHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateManufacturerCommand> Handle(CreateManufacturerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                await _context.Manufacturers.AddAsync(_mapper.Map<Manufacturer>(command), cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return command;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
