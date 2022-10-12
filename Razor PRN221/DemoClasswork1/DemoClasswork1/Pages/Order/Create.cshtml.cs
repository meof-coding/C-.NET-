using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DemoClasswork1.DataAccess;

namespace DemoClasswork1.Pages.Order
{
    public class CreateModel : PageModel
    {
        private readonly DemoClasswork1.DataAccess.NorthwindContext _context;

        public CreateModel(DemoClasswork1.DataAccess.NorthwindContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
        ViewData["ShipVia"] = new SelectList(_context.Shippers, "ShipperId", "ShipperId");
            return Page();
        }

        [BindProperty]
        public DataAccess.Order Order { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
