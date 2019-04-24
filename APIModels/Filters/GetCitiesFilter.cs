using APIModels.Requests.Cities;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetCitiesFilter
    {
        public GetCitiesRequest Filter { get; set; }

        public ISpecification<City> HasName =>
            new ExpressionSpecification<City>(o => o.Name.Equals(Filter.Name));

        public ISpecification<City> CountryId =>
            new ExpressionSpecification<City>(o => o.CountryId == Filter.CountryId);

        public ISpecification<City> HasAll => HasName.And(CountryId);

        public ISpecification<City> OneOfAll => HasName.Or(CountryId);

        public GetCitiesFilter(GetCitiesRequest filter)
        {
            Filter = filter;
        }
    }
}