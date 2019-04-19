using System.Collections.Generic;
using CQS.Requests.Products;
using CQS.Specification;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Products
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
        public static GetProductsRequest Filter { get; set; }

        public static ISpecification<Product> HasName =
            new ExpressionSpecification<Product>(o => o.Name.Equals(Filter.Name));

        public static ISpecification<Product> MinAvailability =
            new ExpressionSpecification<Product>(o => o.Availability > Filter.MinAvailability);
        public static ISpecification<Product> MaxAvailability =
            new ExpressionSpecification<Product>(o => o.Availability < Filter.MaxAvailability);

        public static ISpecification<Product> MinPrice =
            new ExpressionSpecification<Product>(o => o.Price > Filter.MinPrice);
        public static ISpecification<Product> MaxPrice =
            new ExpressionSpecification<Product>(o => o.Price < Filter.MaxPrice);

        public static ISpecification<Product> TypeId =
            new ExpressionSpecification<Product>(o => o.TypeId == Filter.TypeId);

        public static ISpecification<Product> ManufacturerId =
            new ExpressionSpecification<Product>(o => o.ManufacturerId == Filter.ManufacturerId);

        public ISpecification<Product> oneOfAll = HasName.Or(MinAvailability).Or(MaxAvailability).Or(MinPrice).Or(MaxPrice).Or(TypeId).Or(ManufacturerId);

        public GetProductsQuery(GetProductsRequest filter)
        {
            Filter = filter;
        }
    }
}