using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.UsersRoles
{
    public class UserRolesRoleIdSpecification : Specification<UserRoles>
    {
        private readonly int? _roleId;

        public UserRolesRoleIdSpecification(int? roleId)
        {
            _roleId = roleId;
        }

        public override Expression<Func<UserRoles, bool>> ToExpression()
        {
            return _roleId.HasValue
                ? x => x.RoleId == _roleId
                : (Expression<Func<UserRoles, bool>>)(x => true);
        }
    }
}
