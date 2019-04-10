﻿using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Products
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateProductHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateProductCommand> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            try
            {
                await _context.Products.AddAsync(_mapper.Map<Product>(command), cancellationToken);
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
