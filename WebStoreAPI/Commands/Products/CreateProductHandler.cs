using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Post request handler for product
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly WebStoreContext _context;
        private readonly IValidator<Product> _productValidator;

        public CreateProductHandler(WebStoreContext context, IValidator<Product> productValidator)
        {
            _context = context;
            _productValidator = productValidator;
        }

        public async Task<Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(command.Product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return command.Product;
        }
    }
}
