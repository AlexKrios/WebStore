using System;
using System.Linq.Expressions;
using LinqSpecs;
using Type = DataLibrary.Entities.Type;

namespace WebStoreAPI.Specifications.Types
{
    public class TypeNameSpecification : Specification<Type>
    {
        private readonly string _name;

        public TypeNameSpecification(string name)
        {
            _name = name;
        }

        public override Expression<Func<Type, bool>> ToExpression()
        {
            return string.IsNullOrEmpty(_name)
                ? (Expression<Func<Type, bool>>) (x => true)
                : x => x.Name.Equals(_name);
        }
    }
}
