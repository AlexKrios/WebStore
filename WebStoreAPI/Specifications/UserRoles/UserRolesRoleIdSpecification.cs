using System;
using System.Linq.Expressions;
using LinqSpecs;

namespace WebStoreAPI.Specifications.UserRoles
{
    public class UserRolesRoleIdSpecification : Specification<DataLibrary.Entities.UserRole>
    {
        private readonly int? _roleId;

        public UserRolesRoleIdSpecification(int? roleId)
        {
            _roleId = roleId;
        }

        public override Expression<Func<DataLibrary.Entities.UserRole, bool>> ToExpression()
        {
            return _roleId.HasValue
                ? x => x.RoleId == _roleId
                : (Expression<Func<DataLibrary.Entities.UserRole, bool>>)(x => true);
        }
    }
}
