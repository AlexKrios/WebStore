using DataLibrary.Entities;
using Specification.Requests.Roles;

namespace Specification.Specification.Filters
{
    public class GetRolesFilter
    {
        public static GetRolesRequest Filter { get; set; }

        public ISpecification<Role> HasName =
            new ExpressionSpecification<Role>(o => o.Name.Equals(Filter.Name));

        public GetRolesFilter(GetRolesRequest filter)
        {
            Filter = filter;
        }
    }
}
