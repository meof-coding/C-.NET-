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
    public class CategoriesController : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();

        // GET: api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            return repository.GetCategories();
        }

    }
}
