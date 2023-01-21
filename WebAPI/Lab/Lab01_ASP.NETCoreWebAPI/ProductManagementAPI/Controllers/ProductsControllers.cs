using Bussiness_Object;
using Bussiness_Object.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace ProductManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();

        //GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(repository.GetProducts());
        }

        //GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var p = repository.GetProductById(id);
            if (p == null)
            {
                return NotFound();
            }
            return p;
        }

        //POST: ProductsController/Products
        [HttpPost]
        public IActionResult PostProduct(Product p)
        {
            repository.SaveProduct(p);
            return NoContent();
        }

        //GET: ProductsController/Delete/5
        [HttpDelete("id")]
        public IActionResult DeleteProduct(int id)
        {
            var p = repository.GetProductById(id);
            if (p == null)
            {
                return NotFound();
            }
            repository.DeleteProduct(p);
            return NoContent();
        }

        [HttpPut("id")]
        public IActionResult UpdateProduct([FromQuery] int id, Product p)
        {
            var pTmp = repository.GetProductById(id);
            if (pTmp == null)
            {
                return NotFound();
            }
            repository.UpdateProduct(p);
            return NoContent();
        }
    }
}