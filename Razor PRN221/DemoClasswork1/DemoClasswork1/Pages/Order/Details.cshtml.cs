using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoClasswork1.DataAccess;

namespace DemoClasswork1.Pages.Order
{
    public class DetailsModel : PageModel
    {
        private readonly DemoClasswork1.DataAccess.NorthwindContext _context;

        public DetailsModel(DemoClasswork1.DataAccess.NorthwindContext context)
        {
            _context = context;
        }

      public DataAccess.Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            else 
            {
                Order = order;
            }
            return Page();
        }
    }
}
