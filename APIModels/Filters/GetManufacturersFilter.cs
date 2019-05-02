using APIModels.Requests.Manufacturers;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetManufacturersFilter
    {
        public GetManufacturersRequest Request { get; set; }

        public ISpecification<Manufacturer> NameEquals =>
            new ExpressionSpecification<Manufacturer>(o => o.Name.Equals(Request.Name));

        public ISpecification<Manufacturer> MinRating =>
            new ExpressionSpecification<Manufacturer>(o => o.Rating >= Request.MinRating);
        public ISpecification<Manufacturer> MaxRating =>
            new ExpressionSpecification<Manufacturer>(o => o.Rating <= Request.MaxRating);
    }
}
