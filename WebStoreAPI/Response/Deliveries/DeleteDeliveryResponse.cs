﻿namespace WebStoreAPI.Response.Deliveries
{
    public class DeleteDeliveryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Rating { get; set; }
    }
}