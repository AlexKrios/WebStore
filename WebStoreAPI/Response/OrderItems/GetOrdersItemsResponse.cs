﻿namespace WebStoreAPI.Response.OrderItems
{
    public class GetOrdersItemsResponse
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}