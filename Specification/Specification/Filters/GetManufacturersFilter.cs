using DataLibrary.Entities;
using Specification.Requests.Manufacturers;

namespace Specification.Specification.Filters
{
    public class GetManufacturersFilter
    {
        public static GetManufacturersRequest Filter { get; set; }

        public static ISpecification<Manufacturer> HasName =
            new ExpressionSpecification<Manufacturer>(o => o.Name.Equals(Filter.Name));

        public static ISpecification<Manufacturer> MinRating =
            new ExpressionSpecification<Manufacturer>(o => o.Rating >= Filter.MinRating);
        public static ISpecification<Manufacturer> MaxRating =
            new ExpressionSpecification<Manufacturer>(o => o.Rating <= Filter.MaxRating);

        public ISpecification<Manufacturer> OneOfAll = HasName.Or(MinRating).Or(MaxRating);

        public GetManufacturersFilter(GetManufacturersRequest filter)
        {
            Filter = filter;
        }
    }
}
