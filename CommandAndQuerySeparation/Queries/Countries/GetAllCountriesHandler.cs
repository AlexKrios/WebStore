using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Countries
{
    public class GetAllCountriesHandler : IRequestHandler<GetAllCountriesQuery, IEnumerable<GetAllCountriesQuery>>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetAllCountriesHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllCountriesQuery>> Handle(GetAllCountriesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var countries = await _context.Countries.ToListAsync(cancellationToken);
                var result = _mapper.Map<IEnumerable<Country>, IEnumerable<GetAllCountriesQuery>>(countries);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}