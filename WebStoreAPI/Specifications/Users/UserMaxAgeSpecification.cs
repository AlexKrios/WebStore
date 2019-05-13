using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Users
{
    public class UserMaxAgeSpecification : Specification<User>
    {
        private readonly int? _age;

        public UserMaxAgeSpecification(int? age)
        {
            _age = age;
        }

        public override Expression<Func<User, bool>> ToExpression()
        {
            return !_age.HasValue ? (Expression<Func<User, bool>>) (x => true) : x => x.Age <= _age;
        }
    }
}
