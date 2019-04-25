using APIModels.Requests.Cities;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetCitiesFilter
    {
        public GetCitiesRequest Filter { get; set; }

        public ISpecification<City> NameEquals =>
            new ExpressionSpecification<City>(o =>
                string.IsNullOrEmpty(Filter.Name) || string.IsNullOrWhiteSpace(Filter.Name) || o.Name.Equals(Filter.Name));

        public ISpecification<City> CountryId =>
            new ExpressionSpecification<City>(o =>
                !Filter.CountryId.HasValue || Filter.CountryId.Value.Equals(0) || o.CountryId == Filter.CountryId);

        public ISpecification<City> AllEquals => NameEquals.And(CountryId);

        public ISpecification<City> OneOfAll => NameEquals.Or(CountryId);

        public GetCitiesFilter(GetCitiesRequest filter)
        {
            Filter = filter;
        }
    }
}