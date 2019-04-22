using DataLibrary.Entities;
using Specification.Requests.UserRoles;

namespace Specification.Specification.Filters
{
    public class GetUsersRolesFilter
    {
        public static GetUsersRolesRequest Filter { get; set; }

        public static ISpecification<UserRole> UserId =
            new ExpressionSpecification<UserRole>(o => o.UserId >= Filter.UserId);
        public static ISpecification<UserRole> RoleId =
            new ExpressionSpecification<UserRole>(o => o.RoleId <= Filter.RoleId);

        public ISpecification<UserRole> OneOfAll = UserId.Or(RoleId);

        public GetUsersRolesFilter(GetUsersRolesRequest filter)
        {
            Filter = filter;
        }
    }
}
