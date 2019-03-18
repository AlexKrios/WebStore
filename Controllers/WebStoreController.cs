using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStoreAPI.Model;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class WebStoreController : Controller
    {
        WebStoreContext db;
        //Initialization databse and paste start products, users
        public WebStoreController(WebStoreContext context)
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

            db.Products.Add(product);
            db.SaveChanges();
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

            db.Update(product);
            db.SaveChanges();
            return Ok(product);
        }

        //Delete product 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return NotFound();

            db.Products.Remove(product);
            db.SaveChanges();
            return Ok(product);
        }
    }
}
