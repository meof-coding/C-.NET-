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
    public class IndexModel : PageModel
    {
        private readonly DemoClasswork1.DataAccess.NorthwindContext _context;

        public IndexModel(DemoClasswork1.DataAccess.NorthwindContext context)
        {
            _context = context;
        }

        public IList<DataAccess.Order> Order { get;set; } = default!;

        public async Task OnGetAsync(int? Id)
        {
            IQueryable<DataAccess.Order> query = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.ShipViaNavigation); 
            if (Id != 0)
            {
                Order = await query.Where(o => o.EmployeeId == Id).Take(30).ToArrayAsync();
            }
            else
            {
                Order = await query.Take(30).ToArrayAsync();

            }
        }
    }
}
