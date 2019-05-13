using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Users
{
    public class UserEmailSpecification : Specification<User>
    {
        private readonly string _email;

        public UserEmailSpecification(string email)
        {
            _email = email;
        }

        public override Expression<Func<User, bool>> ToExpression()
        {
            return string.IsNullOrEmpty(_email)
                ? (Expression<Func<User, bool>>) (x => true)
                : x => x.Email.Equals(_email);
        }
    }
}
