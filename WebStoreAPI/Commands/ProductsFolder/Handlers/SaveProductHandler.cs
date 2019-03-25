using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.ProductsFolder.Handlers
{
    public class SaveProductHandler : Command
    {
        public SaveProductHandler(WebStoreContext context) : base(context)
        {
        }

        public override void Execute()
        {
            Context.SaveChanges();
        }
    }
}
