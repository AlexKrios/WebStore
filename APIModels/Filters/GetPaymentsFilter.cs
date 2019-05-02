using APIModels.Requests.Payments;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetPaymentsFilter
    {
        public GetPaymentsRequest Request { get; set; }

        public ISpecification<Payment> NameEquals =>
            new ExpressionSpecification<Payment>(o => o.Name.Equals(Request.Name));

        public ISpecification<Payment> MinTaxes =>
            new ExpressionSpecification<Payment>(o => o.Taxes >= Request.MinTaxes);
        public ISpecification<Payment> MaxTaxes =>
            new ExpressionSpecification<Payment>(o => o.Taxes <= Request.MaxTaxes);
    }
}
