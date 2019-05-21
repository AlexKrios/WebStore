using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Roles
{
    public class RoleNameSpecification : Specification<Role>
    {
        private readonly string _name;

        public RoleNameSpecification(string name)
        {
            _name = name;
        }

        public override Expression<Func<Role, bool>> ToExpression()
        {
            return string.IsNullOrEmpty(_name)
                ? (Expression<Func<Role, bool>>) (x => true)
                : x => x.Name.Equals(_name);
        }
    }
}
