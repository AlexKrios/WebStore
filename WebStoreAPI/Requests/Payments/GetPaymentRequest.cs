namespace WebStoreAPI.Requests.Payments
{
    public class GetPaymentRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Taxes { get; set; }
    }
}
