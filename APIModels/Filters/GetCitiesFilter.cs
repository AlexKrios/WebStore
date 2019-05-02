using APIModels.Requests.Cities;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetCitiesFilter
    {
        public GetCitiesRequest Request { get; set; }

        public ISpecification<City> NameEquals =>
            new ExpressionSpecification<City>(o => o.Name.Equals(Request.Name));

        public ISpecification<City> CountryId =>
            new ExpressionSpecification<City>(o => o.CountryId == Request.CountryId);
    }
}