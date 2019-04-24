using APIModels.Requests.UserRoles;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetUsersRolesFilter
    {
        public GetUsersRolesRequest Filter { get; set; }

        public ISpecification<UserRole> UserId =>
            new ExpressionSpecification<UserRole>(o => o.UserId >= Filter.UserId);
        public ISpecification<UserRole> RoleId =>
            new ExpressionSpecification<UserRole>(o => o.RoleId <= Filter.RoleId);

        public ISpecification<UserRole> HasAll => UserId.And(RoleId);

        public ISpecification<UserRole> OneOfAll => UserId.Or(RoleId);

        public GetUsersRolesFilter(GetUsersRolesRequest filter)
        {
            Filter = filter;
        }
    }
}
