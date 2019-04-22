using DataLibrary.Entities;
using Specification.Requests.Countries;

namespace Specification.Specification.Filters
{
    public class GetCountriesFilter
    {
        public static GetCountriesRequest Filter { get; set; }

        public ISpecification<Country> HasName =
            new ExpressionSpecification<Country>(o => o.Name.Equals(Filter.Name));

        public GetCountriesFilter(GetCountriesRequest filter)
        {
            Filter = filter;
        }
    }
}
