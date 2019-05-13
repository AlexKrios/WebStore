using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.UsersRoles
{
    public class UserRolesUserIdSpecification : Specification<UserRoles>
    {
        private readonly int? _userId;

        public UserRolesUserIdSpecification(int? userId)
        {
            _userId = userId;
        }

        public override Expression<Func<UserRoles, bool>> ToExpression()
        {
            return _userId.HasValue
                ? x => x.UserId == _userId
                : (Expression<Func<UserRoles, bool>>)(x => true);
        }
    }
}
