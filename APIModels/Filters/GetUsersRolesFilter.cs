using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetUsersRolesFilter
    {
        public GetUsersRolesRequest Request { get; set; }

        public ISpecification<UserRole> UserId =>
            new ExpressionSpecification<UserRole>(o => o.UserId == Request.UserId);
        public ISpecification<UserRole> RoleId =>
            new ExpressionSpecification<UserRole>(o => o.RoleId == Request.RoleId);
    }
}
