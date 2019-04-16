﻿namespace WebStoreAPI.Requests.Payments
{
    public class GetPaymentsRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Taxes { get; set; }
    }
}
