using DataLibrary.Entities;
using Specification.Requests.Cities;

namespace Specification.Specification.Filters
{
    public class GetCitiesFilter
    {
        public static GetCitiesRequest Filter { get; set; }

        public static ISpecification<City> HasName =
            new ExpressionSpecification<City>(o => o.Name.Equals(Filter.Name));

        public static ISpecification<City> CountryId =
            new ExpressionSpecification<City>(o => o.CountryId == Filter.CountryId);

        public ISpecification<City> OneOfAll = HasName.Or(CountryId);

        public GetCitiesFilter(GetCitiesRequest filter)
        {
            Filter = filter;
        }
    }
}
