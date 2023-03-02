using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ODataBookStoreWebClient.Entity;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace ODataBookStoreWebClient.Controllers
{
    public class BookController : Controller
    {
        private readonly HttpClient client = null;
        private string ProductApiUrl = "";

        public BookController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "https://localhost:7075/odata/Books";
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
            string strData = await response.Content.ReadAsStringAsync();

            dynamic temp = JObject.Parse(strData);
            var lst = temp.value;
            List<Book> items = ((JArray)temp.value).Select(x => new Book
            {
                Id = (int)x["Id"],
                Author = (string)x["Author"],
                ISBN = (string)x["ISBN"],
                Title = (string)x["Title"],
                Price = (decimal)x["Price"],
            }).ToList();
            return View(items);
        }

        //Detail
        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl + "(" + id + ")?$expand= Press");
            string strData = await response.Content.ReadAsStringAsync();

            dynamic temp = JObject.Parse(strData);
            var lst = temp.value;
            Book item = new Book
            {
                Id = (int)temp["Id"],
                Author = (string)temp["Author"],
                ISBN = (string)temp["ISBN"],
                Title = (string)temp["Title"],
                Price = (decimal)temp["Price"],
                Location = new Address { City = (string)temp["Location"]["City"], Street = (string)temp["Location"]["Street"] },
                Press = new Press
                {
                    Name = (string)temp["Press"]["Name"],
                    Category = Enum.GetName(ODataBookStore.Category.Book),
                }
            };
            return View(item);
        }

        //Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            Book item = new Book
            {
                Author = collection["Author"],
                ISBN = collection["ISBN"],
                Title = collection["Title"],
                Price = decimal.Parse(collection["Price"]),
                Location = new Address { City = " ", Street = " " },
                Press = new Press
                {
                    Name = " ",
                    Category = Enum.GetName(ODataBookStore.Category.Book),
                }
            };
            string strData = JsonConvert.SerializeObject(item);
            HttpContent content = new StringContent(strData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(ProductApiUrl, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //Edit
        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl + "(" + id + ")?$expand= Press");
            string strData = await response.Content.ReadAsStringAsync();

            dynamic temp = JObject.Parse(strData);
            var lst = temp.value;
            Book item = new Book
            {
                Id = (int)temp["Id"],
                Author = (string)temp["Author"],
                ISBN = (string)temp["ISBN"],
                Title = (string)temp["Title"],
                Price = (decimal)temp["Price"],
                Location = new Address { City = (string)temp["Location"]["City"], Street = (string)temp["Location"]["Street"] },
                Press = new Press
                {
                    Id = (int)temp["Press"]["Id"],
                    Name = (string)temp["Press"]["Name"],
                    Category = (string)temp["Press"]["Category"],
                }
            };
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            Book item = new Book
            {
                Id = id,
                Author = collection["Author"],
                ISBN = collection["ISBN"],
                Title = collection["Title"],
                Price = decimal.Parse(collection["Price"]),
                Location = new Address { City = collection["Location.City"], Street = collection["Location.Street"] },
                Press = new Press
                {
                    Name = collection["Press.Name"],
                    //parse collection["Press.Category"] to enum
                    Category = Enum.Parse(typeof(ODataBookStore.Category), collection["Press.Category"].ToString()).ToString(),
                }
            };
            string strData = JsonConvert.SerializeObject(item);
            StringContent content = new StringContent(strData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PatchAsync(ProductApiUrl + "(" + id + ")", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl + "(" + id + ")");
            string strData = await response.Content.ReadAsStringAsync();

            dynamic temp = JObject.Parse(strData);
            var lst = temp.value;
            Book item = new Book
            {
                Id = (int)temp["Id"],
                Author = (string)temp["Author"],
                ISBN = (string)temp["ISBN"],
                Title = (string)temp["Title"],
                Price = (decimal)temp["Price"],
            };
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            HttpResponseMessage response = await client.DeleteAsync(ProductApiUrl + "(" + id + ")");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}