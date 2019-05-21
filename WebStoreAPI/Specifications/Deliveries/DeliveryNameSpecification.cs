using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Deliveries
{
    public class DeliveryNameSpecification : Specification<Delivery>
    {
        private readonly string _name;

        public DeliveryNameSpecification(string name)
        {
            _name = name;
        }

        public override Expression<Func<Delivery, bool>> ToExpression()
        {
            return string.IsNullOrEmpty(_name)
                ? (Expression<Func<Delivery, bool>>) (x => true)
                : x => x.Name.Equals(_name);
        }
    }
}
