using DataLibrary.Entities;
using Specification.Requests.Products;

namespace Specification.Specification.Filters
{
    public class GetProductsFilter
    {
        public static GetProductsRequest Filter { get; set; }

        public static ISpecification<Product> HasName =
            new ExpressionSpecification<Product>(o => o.Name.Equals(Filter.Name));

        public static ISpecification<Product> MinAvailability =
            new ExpressionSpecification<Product>(o => o.Availability >= Filter.MinAvailability);
        public static ISpecification<Product> MaxAvailability =
            new ExpressionSpecification<Product>(o => o.Availability <= Filter.MaxAvailability);

        public static ISpecification<Product> MinPrice =
            new ExpressionSpecification<Product>(o => o.Price >= Filter.MinPrice);
        public static ISpecification<Product> MaxPrice =
            new ExpressionSpecification<Product>(o => o.Price <= Filter.MaxPrice);

        public static ISpecification<Product> TypeId =
            new ExpressionSpecification<Product>(o => o.TypeId == Filter.TypeId);

        public static ISpecification<Product> ManufacturerId =
            new ExpressionSpecification<Product>(o => o.ManufacturerId == Filter.ManufacturerId);

        public ISpecification<Product> OneOfAll = HasName.Or(MinAvailability).Or(MaxAvailability).Or(MinPrice).Or(MaxPrice).Or(TypeId).Or(ManufacturerId);

        public GetProductsFilter(GetProductsRequest filter)
        {
            Filter = filter;
        }
    }
}
