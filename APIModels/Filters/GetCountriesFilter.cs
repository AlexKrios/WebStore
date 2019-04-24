using APIModels.Requests.Countries;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetCountriesFilter
    {
        public GetCountriesRequest Filter { get; set; }

        public ISpecification<Country> HasName =>
            new ExpressionSpecification<Country>(o => o.Name.Equals(Filter.Name));

        public GetCountriesFilter(GetCountriesRequest filter)
        {
            Filter = filter;
        }
    }
}