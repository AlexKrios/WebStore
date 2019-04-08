using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Commands.Manufacturers
{
    public class UpdateManufacturerHandler : IRequestHandler<UpdateManufacturerCommand, UpdateManufacturerCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateManufacturerHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateManufacturerCommand> Handle(UpdateManufacturerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Manufacturers.Any(x => x.Id == command.Id)) return null;

                _context.Manufacturers.Update(_mapper.Map<Manufacturer>(command));
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