using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApplication2.Models;

namespace WebApplication2.Pages.List
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication2.Models.PRN221_Spr22Context _context;
        private IHostingEnvironment _environment;
        public IndexModel(WebApplication2.Models.PRN221_Spr22Context context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IList<Service> Service { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        [BindProperty]
        public IFormFile JsonFile { get; set; }
        public async Task OnGetAsync()
        {
            //Get instance of service
            var services = _context.Services
                .Include(s => s.EmployeeNavigation).Select(x => new Service { RoomTitle = x.RoomTitle, FeeType = x.FeeType, Month = x.Month, Year = x.Year, Amount = x.Amount, EmployeeNavigation = x.EmployeeNavigation });
            //C1: Search if RoomTitle contains SearchString
            /*
             * if (!string.IsNullOrEmpty(SearchString))
            {
                services = services.Where(s => s.RoomTitle.Contains(SearchString));
            }
            */
            //C2: SEarch if any service contains SearchString
            if (!string.IsNullOrEmpty(SearchString))
            {
                services = services.Where(s => s.RoomTitle.Contains(SearchString) || s.FeeType.Contains(SearchString));
            }
            Service = await services.ToListAsync();
        }
        public async Task OnPostAsync()
        {
            var file = Path.Combine(_environment.ContentRootPath, "Uploads", JsonFile.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await JsonFile.CopyToAsync(fileStream);
            }
            StreamReader streamReader = new StreamReader(file);
            string data = streamReader.ReadToEnd();
            Service = JsonConvert.DeserializeObject<List<Service>>(data);
            foreach (var item in Service)
            {
                Service services = new Service()
                {
                    RoomTitle = item.RoomTitle,
                    //Id = item.Id,
                    Month = item.Month,
                    Year = item.Year,
                    FeeType = item.FeeType,
                    Amount = item.Amount,
                    PaymentDate = item.PaymentDate,
                    Employee = item.Employee,
                };
                _context.Services.Add(services);
                await _context.SaveChangesAsync();
            }
            Service = await _context.Services
                .Include(s => s.EmployeeNavigation).ToListAsync();
        }
    }
}
