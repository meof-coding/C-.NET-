using Bussiness_Object;
using Bussiness_Object.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductManagementWebClient.Models;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ProductManagementWebClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient client = null;
        private string ProductApiUrl = "";

        public ProductController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "https://localhost:7118/api/products";
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(strData, options);
            return View(products);
        }

        //GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(new NorthwindContext().Categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(new NorthwindContext().Suppliers, "SupplierId", "CompanyName");
            return View();
        }

        //POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (ModelState.IsValid)
            {
                string strData = JsonSerializer.Serialize(product);
                StringContent content = new StringContent(strData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(ProductApiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["CategoryId"] = new SelectList(new NorthwindContext().Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(new NorthwindContext().Suppliers, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl + "/" + id);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Product product = JsonSerializer.Deserialize<Product>(strData, options);
            return View(product);
        }

        //GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl + "/" + id);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Product product = JsonSerializer.Deserialize<Product>(strData, options);
            ViewData["CategoryId"] = new SelectList(new NorthwindContext().Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(new NorthwindContext().Suppliers, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string strData = JsonSerializer.Serialize<Product>(product);
                    //convert strData to httpContent
                    HttpContent content = new StringContent(strData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync(ProductApiUrl + "/id?id=" + id, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw new Exception("Product not found");
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(new NorthwindContext().Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(new NorthwindContext().Suppliers, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl + "/" + id);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Product product = JsonSerializer.Deserialize<Product>(strData, options);
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(ProductApiUrl + "/id?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}