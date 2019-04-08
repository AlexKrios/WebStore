﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Commands.Countries
{
    public class CreateCountryHandler : IRequestHandler<CreateCountryCommand, CreateCountryCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateCountryHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateCountryCommand> Handle(CreateCountryCommand command, CancellationToken cancellationToken)
        {
            await _context.Countries.AddAsync(_mapper.Map<Country>(command), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return command;
        }
    }
}
