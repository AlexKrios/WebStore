using System.Threading.Tasks;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Post request handler for product
    public class PostProductHandler : ICommandHandler<PostProductCommand>
    {
        private readonly WebStoreContext _context;

        public PostProductHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task Execute(PostProductCommand command)
        {
            await _context.Products.AddAsync(command.Product);
            await _context.SaveChangesAsync();
        }
    }
}
