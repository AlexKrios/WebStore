using System;
using System.Linq.Expressions;
using LinqSpecs;

namespace WebStoreAPI.Specifications.UserRoles
{
    public class UserRolesUserIdSpecification : Specification<DataLibrary.Entities.UserRoles>
    {
        private readonly int? _userId;

        public UserRolesUserIdSpecification(int? userId)
        {
            _userId = userId;
        }

        public override Expression<Func<DataLibrary.Entities.UserRoles, bool>> ToExpression()
        {
            return _userId.HasValue
                ? x => x.UserId == _userId
                : (Expression<Func<DataLibrary.Entities.UserRoles, bool>>)(x => true);
        }
    }
}
