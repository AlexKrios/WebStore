using System.ComponentModel.DataAnnotations;
using MediatR;

namespace WebStoreAPI.Commands.Products
{
    //Post request command for product
    public class CreateProductCommand : IRequest<CreateProductCommand>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }
    }
}
