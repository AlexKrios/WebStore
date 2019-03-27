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
            _context.Products.Add(command.Id);
            await _context.SaveChangesAsync();
        }
    }
}
