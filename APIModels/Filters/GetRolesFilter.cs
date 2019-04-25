using APIModels.Requests.Roles;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetRolesFilter
    {
        public GetRolesRequest Filter { get; set; }

        public ISpecification<Role> NameEquals =>
            new ExpressionSpecification<Role>(o => o.Name.Equals(Filter.Name));

        public GetRolesFilter(GetRolesRequest filter)
        {
            Filter = filter;
        }
    }
}
