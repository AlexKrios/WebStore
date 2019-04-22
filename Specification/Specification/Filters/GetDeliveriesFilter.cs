using DataLibrary.Entities;
using Specification.Requests.Deliveries;

namespace Specification.Specification.Filters
{
    public class GetDeliveriesFilter
    {
        public static GetDeliveriesRequest Filter { get; set; }

        public static ISpecification<Delivery> HasName =
            new ExpressionSpecification<Delivery>(o => o.Name.Equals(Filter.Name));

        public static ISpecification<Delivery> MinPrice =
            new ExpressionSpecification<Delivery>(o => o.Price >= Filter.MinPrice);
        public static ISpecification<Delivery> MaxPrice =
            new ExpressionSpecification<Delivery>(o => o.Price <= Filter.MaxPrice);

        public static ISpecification<Delivery> MinRating =
            new ExpressionSpecification<Delivery>(o => o.Rating >= Filter.MinRating);
        public static ISpecification<Delivery> MaxRating =
            new ExpressionSpecification<Delivery>(o => o.Rating <= Filter.MaxRating);

        public ISpecification<Delivery> OneOfAll =
            HasName.Or(MinPrice).Or(MaxPrice).Or(MinRating).Or(MaxRating);

        public GetDeliveriesFilter(GetDeliveriesRequest filter)
        {
            Filter = filter;
        }
    }
}
