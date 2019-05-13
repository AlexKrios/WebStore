using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Users
{
    public class UserNameSpecification : Specification<User>
    {
        private readonly string _name;

        public UserNameSpecification(string name)
        {
            _name = name;
        }

        public override Expression<Func<User, bool>> ToExpression()
        {
            return string.IsNullOrEmpty(_name)
                ? (Expression<Func<User, bool>>) (x => true)
                : x => x.Name.Equals(_name);
        }
    }
}
