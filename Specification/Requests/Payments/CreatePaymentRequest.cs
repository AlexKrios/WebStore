namespace Specification.Requests.Payments
{
    public class CreatePaymentRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Taxes { get; set; }
    }
}
