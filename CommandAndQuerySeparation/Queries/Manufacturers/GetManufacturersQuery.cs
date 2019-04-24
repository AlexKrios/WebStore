using System.Collections.Generic;
using APIModels.Filters;
using APIModels.Requests.Manufacturers;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Manufacturers
{
    public class GetManufacturersQuery : IRequest<IEnumerable<Manufacturer>>
    {
        public GetManufacturersFilter Filter { get; set; }

        public GetManufacturersQuery(GetManufacturersRequest filter)
        {
            Filter = new GetManufacturersFilter(filter);
        }
    }
}
