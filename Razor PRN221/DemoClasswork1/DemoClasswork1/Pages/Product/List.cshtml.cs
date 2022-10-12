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

        public IList<DataAccess.Product> Product { get; set; } = default!;
        public IList<DataAccess.Category> Categories { get; set; } = default!;

        [BindProperty]
        public List<int> CateId { get; set; }
        public async Task OnGetAsync(int? currentpage)
        {
            Categories = _context.Categories.ToList();
            IQueryable<DataAccess.Product> query = GetProducts();
            Product= query.ToList();
            await Pagination(currentpage, query);
        }

        private IQueryable<DataAccess.Product> GetProducts()
        {
            IQueryable<DataAccess.Product> query = _context.Products
                .Include(o => o.Category)
                .Include(o => o.Supplier);
            return query;
        }

        public async Task<IActionResult> OnPostAsync(string productName, int? lowestPrice, int? highestPrice, int? pageIndex, List<int?> CateId)
        {
            CurrentFilter = productName;
            Categories = _context.Categories.ToList();
            IQueryable<DataAccess.Product> query = GetProducts();
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
            return Page();
        }

        private async Task Pagination(int? pageIndex, IQueryable<DataAccess.Product> query)
        {
            PageSize = Configuration.GetValue("PageSize", 4);
            ProductsPage = await PaginatedList<DataAccess.Product>.CreateAsync(
                query, pageIndex ?? 1, PageSize);
        }
    }
}
