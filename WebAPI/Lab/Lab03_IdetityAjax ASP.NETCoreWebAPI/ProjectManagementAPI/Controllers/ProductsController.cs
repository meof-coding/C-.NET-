using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.DataAccess;
using Repositories;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return repository.GetProducts();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = repository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("id")]
        public IActionResult UpdateProduct([FromQuery]int id,Product product)
        {
            var pTmp = repository.GetProductById(id);
            if (pTmp == null)
            {
                return NotFound();
            }
            repository.UpdateProduct(product);
            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            repository.SaveProduct(product);
            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProduct([FromQuery]int id)
        {
            var pTmp = repository.GetProductById(id);
            if (pTmp == null)
            {
                return NotFound();
            }
            repository.DeleteProduct(pTmp);
            return NoContent();
        }

        //private bool ProductExists(int id)
        //{
        //    return _context.Products.Any(e => e.ProductId == id);
        //}
    }
}
