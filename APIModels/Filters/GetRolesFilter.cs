using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetRolesFilter
    {
        public GetRolesRequest Request { get; set; }

        public ISpecification<Role> NameEquals =>
            new ExpressionSpecification<Role>(o => o.Name.Equals(Request.Name));
    }
}
