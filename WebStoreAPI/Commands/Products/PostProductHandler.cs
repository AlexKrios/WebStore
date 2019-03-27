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

        public void Execute(PostProductCommand command)
        {
            _context.Products.Add(command.Id);
            _context.SaveChanges();
        }
    }
}
