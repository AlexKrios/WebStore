﻿namespace APIModels.Response.OrderItems
{
    public class CreateOrderItemsResponse
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}