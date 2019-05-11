using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetCountriesFilter
    {
        public GetCountriesRequest Request { get; set; }

        public ISpecification<Country> NameEquals =>
            new ExpressionSpecification<Country>(o => o.Name.Equals(Request.Name));
    }
}