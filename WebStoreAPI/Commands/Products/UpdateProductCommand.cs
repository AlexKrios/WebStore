using MediatR;

namespace WebStoreAPI.Commands.Products
{
    //Put request command for product
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
    }
}
