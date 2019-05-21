using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Payments
{
    public class PaymentMaxTaxesSpecification : Specification<Payment>
    {
        private readonly decimal? _taxes;

        public PaymentMaxTaxesSpecification(decimal? taxes)
        {
            _taxes = taxes;
        }

        public override Expression<Func<Payment, bool>> ToExpression()
        {
            return _taxes.HasValue 
                ? x => x.Taxes <= _taxes
                : (Expression<Func<Payment, bool>>)(x => true);
        }
    }
}
