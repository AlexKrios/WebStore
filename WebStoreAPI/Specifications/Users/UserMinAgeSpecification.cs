using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Users
{
    public class UserMinAgeSpecification : Specification<User>
    {
        private readonly int? _age;

        public UserMinAgeSpecification(int? age)
        {
            _age = age;
        }

        public override Expression<Func<User, bool>> ToExpression()
        {
            return _age.HasValue 
                ? x => x.Age >= _age
                : (Expression<Func<User, bool>>)(x => true);
        }
    }
}
