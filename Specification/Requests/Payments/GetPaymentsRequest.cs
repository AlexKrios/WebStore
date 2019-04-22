namespace Specification.Requests.Payments
{
    public class GetPaymentsRequest
    {
        public string Name { get; set; }
        public decimal? MinTaxes { get; set; }
        public decimal? MaxTaxes { get; set; }
    }
}
