using APIModels.Requests.Deliveries;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetDeliveriesFilter
    {
        public GetDeliveriesRequest Filter { get; set; }

        public ISpecification<Delivery> NameEquals =>
            new ExpressionSpecification<Delivery>(o =>
                string.IsNullOrEmpty(Filter.Name) || string.IsNullOrWhiteSpace(Filter.Name) || o.Name.Equals(Filter.Name));

        public ISpecification<Delivery> MinPrice =>
            new ExpressionSpecification<Delivery>(o => 
                !Filter.MinPrice.HasValue || Filter.MinPrice.Value.Equals(0) || o.Price >= Filter.MinPrice);
        public ISpecification<Delivery> MaxPrice =>
            new ExpressionSpecification<Delivery>(o => 
                !Filter.MaxPrice.HasValue || Filter.MaxPrice.Value.Equals(0) || o.Price <= Filter.MaxPrice);

        public ISpecification<Delivery> MinRating =>
            new ExpressionSpecification<Delivery>(o => 
                !Filter.MinRating.HasValue || Filter.MinRating.Value.Equals(0) || o.Rating >= Filter.MinRating);
        public ISpecification<Delivery> MaxRating =>
            new ExpressionSpecification<Delivery>(o => 
                !Filter.MaxRating.HasValue || Filter.MaxRating.Value.Equals(0) || o.Rating <= Filter.MaxRating);

        public ISpecification<Delivery> AllEquals =>
            NameEquals.And(MinPrice).And(MaxPrice).And(MinRating).And(MaxRating);

        public ISpecification<Delivery> OneOfAll =>
            NameEquals.Or(MinPrice).And(MaxPrice).Or(MinRating).And(MaxRating);

        public GetDeliveriesFilter(GetDeliveriesRequest filter)
        {
            Filter = filter;
        }
    }
}
