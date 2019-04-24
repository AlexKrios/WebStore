using APIModels.Requests.Orders;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetOrdersFilter
    {
        public GetOrdersRequest Filter { get; set; }

        public ISpecification<Order> MinTotalPrice =>
            new ExpressionSpecification<Order>(o => o.TotalPrice >= Filter.MinTotalPrice);
        public ISpecification<Order> MaxTotalPrice =>
            new ExpressionSpecification<Order>(o => o.TotalPrice <= Filter.MaxTotalPrice);

        public ISpecification<Order> UserId =>
            new ExpressionSpecification<Order>(o => o.UserId == Filter.UserId);

        public ISpecification<Order> DeliveryId =>
            new ExpressionSpecification<Order>(o => o.DeliveryId == Filter.DeliveryId);

        public ISpecification<Order> PaymentId =>
            new ExpressionSpecification<Order>(o => o.PaymentId == Filter.PaymentId);

        public ISpecification<Order> HasAll =>
            UserId.And(MinTotalPrice).And(MaxTotalPrice).And(UserId).And(DeliveryId).And(PaymentId);

        public ISpecification<Order> OneOfAll =>
            UserId.Or(MinTotalPrice).Or(MaxTotalPrice).Or(UserId).Or(DeliveryId).Or(PaymentId);

        public GetOrdersFilter(GetOrdersRequest filter)
        {
            Filter = filter;
        }
    }
}
