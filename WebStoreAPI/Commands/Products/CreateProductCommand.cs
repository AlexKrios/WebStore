using MediatR;

namespace WebStoreAPI.Commands.Products
{
    //Post request command for product
    public class CreateProductCommand : IRequest<CreateProductCommand>
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
    }
}
