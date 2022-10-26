using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoClasswork1.DataAccess;

namespace DemoClasswork1.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly DemoClasswork1.DataAccess.NorthwindContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(DemoClasswork1.DataAccess.NorthwindContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public PaginatedList<DataAccess.Product> ProductsPage { get; set; }
        public string CurrentFilter { get; set; }

        public List<int> ListCateId { get; set; }

        public int? LowestPrice { get; set; }

        public int? HighestPrice { get; set; }

        public IList<DataAccess.Product> Product { get; set; } = default!;
        public IList<DataAccess.Category> Categories { get; set; } = default!;

        [BindProperty]
        public List<int> CateId { get; set; }
        public async Task OnGetAsync(int? currentpage, string productName, int? lowestPrice, int? highestPrice)
        {
            List<int> categories = new List<int>();
            if (TempData["Categories"]!=null)
            {
                foreach (var item in (IEnumerable<int>)TempData["Categories"])
                {
                    categories.Add(item);
                }
            }
           
            await GetProducts(productName, lowestPrice, highestPrice, currentpage, categories);
        }

        public async Task<IActionResult> OnPostAsync(string productName, int? lowestPrice, int? highestPrice, int? pageIndex, List<int> CateId)
        {
            CurrentFilter = productName;
            await GetProducts(productName, lowestPrice, highestPrice, pageIndex, CateId);
            return Page();
        }

        private async Task GetProducts(string productName, int? lowestPrice, int? highestPrice, int? pageIndex, List<int> CateId)
        {
            ListCateId = CateId;
            if (ListCateId != null && ListCateId.Count!=0)
            {
                TempData["Categories"] = ListCateId;
            }
            CurrentFilter = productName;
            LowestPrice = lowestPrice;
            HighestPrice = highestPrice;
            Categories = _context.Categories.ToList();
            IQueryable<DataAccess.Product> query = _context.Products
               .Include(o => o.Category)
               .Include(o => o.Supplier);
            if (!String.IsNullOrEmpty(productName))
            {
                query = query.Where(p => p.ProductName.Contains(productName));
            }
            if (CateId.Count > 0)
            {
                query = query.Where(p => CateId.Contains(p.CategoryId));
            }
            if (lowestPrice != null)
            {
                query = query.Where(p => p.UnitPrice >= lowestPrice);
            }
            if (highestPrice != null)
            {
                query = query.Where(p => p.UnitPrice <= highestPrice);
            }
            Product = query.ToList();
            await Pagination(pageIndex, query);
        }

        private async Task Pagination(int? pageIndex, IQueryable<DataAccess.Product> query)
        {
            PageSize = Configuration.GetValue("PageSize", 4);
            ProductsPage = await PaginatedList<DataAccess.Product>.CreateAsync(
                query, pageIndex ?? 1, PageSize);
        }
    }
}
