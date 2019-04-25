using APIModels.Requests.Orders;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetOrdersFilter
    {
        public GetOrdersRequest Filter { get; set; }

        public ISpecification<Order> MinTotalPrice =>
            new ExpressionSpecification<Order>(o => 
                !Filter.MinTotalPrice.HasValue || Filter.MinTotalPrice.Value.Equals(0) || o.TotalPrice >= Filter.MinTotalPrice);
        public ISpecification<Order> MaxTotalPrice =>
            new ExpressionSpecification<Order>(o => 
                !Filter.MaxTotalPrice.HasValue || Filter.MaxTotalPrice.Value.Equals(0) || o.TotalPrice <= Filter.MaxTotalPrice);

        public ISpecification<Order> UserId =>
            new ExpressionSpecification<Order>(o => 
                !Filter.UserId.HasValue || o.UserId == Filter.UserId);

        public ISpecification<Order> DeliveryId =>
            new ExpressionSpecification<Order>(o => 
                !Filter.DeliveryId.HasValue || o.DeliveryId == Filter.DeliveryId);

        public ISpecification<Order> PaymentId =>
            new ExpressionSpecification<Order>(o => 
                !Filter.PaymentId.HasValue || o.PaymentId == Filter.PaymentId);

        public ISpecification<Order> AllEquals =>
            UserId.And(MinTotalPrice).And(MaxTotalPrice).And(UserId).And(DeliveryId).And(PaymentId);

        public ISpecification<Order> OneOfAll =>
            UserId.Or(MinTotalPrice).And(MaxTotalPrice).Or(UserId).Or(DeliveryId).Or(PaymentId);

        public GetOrdersFilter(GetOrdersRequest filter)
        {
            Filter = filter;
        }
    }
}
