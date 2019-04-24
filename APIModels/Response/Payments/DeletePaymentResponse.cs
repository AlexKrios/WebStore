namespace APIModels.Response.Payments
{
    public class DeletePaymentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Taxes { get; set; }
    }
}
