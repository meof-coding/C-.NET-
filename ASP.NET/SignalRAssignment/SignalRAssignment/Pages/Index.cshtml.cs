using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SignalRAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRAssignment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SignalRAssignment.Models.Lab2Context _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, SignalRAssignment.Models.Lab2Context context)
        {
            _logger = logger;
            _context = context;
        }
        public IList<Product> Product { get; set; }
        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Discount)
                .Include(p => p.Supplier).Where(s => s.Discount.ExperiedAt.CompareTo(DateTime.Now) > 0).ToListAsync();
        }
    }
}
