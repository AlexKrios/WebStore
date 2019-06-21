namespace WebStoreAPI.Requests.Payments
{
    public class GetPaymentsRequest
    {
        public string Name { get; set; }
        public decimal? MinTaxes { get; set; }
        public decimal? MaxTaxes { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
