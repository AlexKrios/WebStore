using APIModels.Requests.Deliveries;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetDeliveriesFilter
    {
        public GetDeliveriesRequest Filter { get; set; }

        public ISpecification<Delivery> HasName =>
            new ExpressionSpecification<Delivery>(o => o.Name.Equals(Filter.Name));

        public ISpecification<Delivery> MinPrice =>
            new ExpressionSpecification<Delivery>(o => o.Price >= Filter.MinPrice);
        public ISpecification<Delivery> MaxPrice =>
            new ExpressionSpecification<Delivery>(o => o.Price <= Filter.MaxPrice);

        public ISpecification<Delivery> MinRating =>
            new ExpressionSpecification<Delivery>(o => o.Rating >= Filter.MinRating);
        public ISpecification<Delivery> MaxRating =>
            new ExpressionSpecification<Delivery>(o => o.Rating <= Filter.MaxRating);

        public ISpecification<Delivery> HasAll =>
            HasName.And(MinPrice).And(MaxPrice).And(MinRating).And(MaxRating);

        public ISpecification<Delivery> OneOfAll =>
            HasName.Or(MinPrice).Or(MaxPrice).Or(MinRating).Or(MaxRating);

        public GetDeliveriesFilter(GetDeliveriesRequest filter)
        {
            Filter = filter;
        }
    }
}
