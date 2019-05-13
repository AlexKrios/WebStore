using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Payments
{
    public class PaymentMinTaxesSpecification : Specification<Payment>
    {
        private readonly decimal? _taxes;

        public PaymentMinTaxesSpecification(decimal? taxes)
        {
            _taxes = taxes;
        }

        public override Expression<Func<Payment, bool>> ToExpression()
        {
            return !_taxes.HasValue ? (Expression<Func<Payment, bool>>) (x => true) : x => x.Taxes >= _taxes;
        }
    }
}
