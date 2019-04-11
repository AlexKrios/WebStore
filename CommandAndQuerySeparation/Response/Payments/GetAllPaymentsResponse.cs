namespace CommandAndQuerySeparation.Response.Payments
{
    public class GetAllPaymentsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Taxes { get; set; }
    }
}
