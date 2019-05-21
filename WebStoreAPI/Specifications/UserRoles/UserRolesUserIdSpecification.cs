using System;
using System.Linq.Expressions;
using LinqSpecs;

namespace WebStoreAPI.Specifications.UserRoles
{
    public class UserRolesUserIdSpecification : Specification<DataLibrary.Entities.UserRole>
    {
        private readonly int? _userId;

        public UserRolesUserIdSpecification(int? userId)
        {
            _userId = userId;
        }

        public override Expression<Func<DataLibrary.Entities.UserRole, bool>> ToExpression()
        {
            return _userId.HasValue
                ? x => x.UserId == _userId
                : (Expression<Func<DataLibrary.Entities.UserRole, bool>>)(x => true);
        }
    }
}
