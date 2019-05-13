using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Orders
{
    public class OrderPaymentIdSpecification : Specification<Order>
    {
        private readonly int? _paymentId;

        public OrderPaymentIdSpecification(int? paymentId)
        {
            _paymentId = paymentId;
        }

        public override Expression<Func<Order, bool>> ToExpression()
        {
            return _paymentId.HasValue 
                ? x => x.PaymentId >= _paymentId
                : (Expression<Func<Order, bool>>)(x => true);
        }
    }
}
