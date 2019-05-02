using APIModels.Requests.Types;
using Specification.Specification;
using Type = DataLibrary.Entities.Type;

namespace APIModels.Filters
{
    public class GetTypesFilter
    {
        public GetTypesRequest Request { get; set; }

        public ISpecification<Type> NameEquals =>
            new ExpressionSpecification<Type>(o => o.Name.Equals(Request.Name));
    }
}