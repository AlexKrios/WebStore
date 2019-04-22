using DataLibrary.Entities;
using Specification.Requests.Types;

namespace Specification.Specification.Filters
{
    public class GetTypesFilter
    {
        public static GetTypesRequest Filter { get; set; }

        public ISpecification<Type> HasName =
            new ExpressionSpecification<Type>(o => o.Name.Equals(Filter.Name));

        public GetTypesFilter(GetTypesRequest filter)
        {
            Filter = filter;
        }
    }
}