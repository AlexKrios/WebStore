﻿namespace CommandAndQuerySeparation.Response.Payments
{
    public class GetPaymentByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Taxes { get; set; }
    }
}
