using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Payments
{
    public class PaymentNameSpecification : Specification<Payment>
    {
        private readonly string _name;

        public PaymentNameSpecification(string name)
        {
            _name = name;
        }

        public override Expression<Func<Payment, bool>> ToExpression()
        {
            return string.IsNullOrEmpty(_name)
                ? (Expression<Func<Payment, bool>>) (x => true)
                : x => x.Name.Equals(_name);
        }
    }
}
