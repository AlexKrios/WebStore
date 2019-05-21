﻿namespace WebStoreAPI.Requests.Manufacturers
{
    public class UpdateManufacturerRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public float Rating { get; set; }
    }
}