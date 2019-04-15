namespace WebStoreAPI.Response.Payments
{
    public class CreatePaymentResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Taxes { get; set; }
    }
}
