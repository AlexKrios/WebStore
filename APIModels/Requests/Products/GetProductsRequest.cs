﻿namespace APIModels.Requests.Products
{
    public class GetProductsRequest
    {
        public string Name { get; set; }
        public int? MinAvailability { get; set; }
        public int? MaxAvailability { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? TypeId { get; set; }
        public int? ManufacturerId { get; set; }
    }
}