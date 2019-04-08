using MediatR;

namespace WebStoreAPI.Commands.Products
{
    public class CreateProductCommand : IRequest<CreateProductCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Availability { get; set; }
        public int Price { get; set; }
        public int TypeId { get; set; }
        public int ManufacturerId { get; set; }
        public int UserId { get; set; }
    }
}
