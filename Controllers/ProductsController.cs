using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStoreAPI.Models;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        WebStoreContext db;
        ProductModel pm = new ProductModel();
        //Initialization databse and paste start products, users
        public ProductsController(WebStoreContext context)
        {
            this.db = context;
            DBInit.Init(context);
        }

        //Get list of products
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Products);
        }

        //Get single product
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product product = db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        //Add new product
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (product == null)
                return BadRequest();

            pm.Post(db, product);
            return Ok(product);
        }

        //Change product
        [HttpPut]
        public IActionResult Put([FromBody]Product product)
        {
            if (product == null)
                return BadRequest();
            if (!db.Products.Any(x => x.Id == product.Id))
                return NotFound();

            pm.Put(db, product);
            return Ok(product);
        }

        //Delete product 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return NotFound();

            pm.Delete(db, product);
            return Ok(product);
        }
    }
}
