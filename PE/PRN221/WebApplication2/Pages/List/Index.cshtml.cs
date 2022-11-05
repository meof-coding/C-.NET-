using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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
            if (!string.IsNullOrEmpty(SearchString))
            {
                services = services.Where(s => s.RoomTitle.Contains(SearchString));
            }
            //get all service where month = 3 and year = 2022
            Service =await services.Where(s => s.Month == 3 && s.Year == 2022).ToListAsync();
        }
        public async Task OnPostAsync()
        {
          
            var file = Path.Combine(_environment.ContentRootPath, "Uploads", JsonFile.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await JsonFile.CopyToAsync(fileStream);
            }
            StreamReader streamReader = new StreamReader(file);
            string xml = streamReader.ReadToEnd();
            /* Minh recommend :) */
            //if (JsonFile == null)
            //{
            //    return Page();
            //}
            //Stream stream = JsonFile.OpenReadStream();
            //StreamReader streamReader1 = new StreamReader(stream);
            //string data = await streamReader1.ReadToEndAsync();

            /*Read Json File Import*/
            //Service = JsonConvert.DeserializeObject<List<Service>>(data);
            //foreach (var item in Service)
            //{
            //    Service services = new Service()
            //    {
            //        RoomTitle = item.RoomTitle,
            //        //Id = item.Id,
            //        Month = item.Month,
            //        Year = item.Year,
            //        FeeType = item.FeeType,
            //        Amount = item.Amount,
            //        PaymentDate = item.PaymentDate,
            //        Employee = item.Employee,
            //    };
            /*Read XML File Import*/
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNode root = doc.DocumentElement;
            var services = root.SelectNodes("descendant::Service");
            foreach (XmlNode item in services)
            {
                Service service = new Service()
                {
                    RoomTitle = item["RoomTitle"].InnerText,
                    //Id = item.Id,
                    Month = Convert.ToByte(item["Month"].InnerText) ,
                    Year = Convert.ToInt32(item["Year"].InnerText),
                    FeeType = item["FeeType"].InnerText,
                    Amount = Convert.ToDecimal(item["Amount"].InnerText),
                };
                if (!string.IsNullOrEmpty(item["PaymentDate"].InnerText))
                {
                    service.PaymentDate = DateTime.Parse(item["PaymentDate"].InnerText); 
                };
                if (!string.IsNullOrEmpty(item["Employee"].InnerText))
                {
                    service.Employee = Convert.ToInt32(item["Employee"].InnerText);
                };
                _context.Services.Add(service);
            };
            await _context.SaveChangesAsync();
            Service = await _context.Services
             .Include(s => s.EmployeeNavigation).Where(s => s.Month == 3 && s.Year == 2022).ToListAsync();
        }
        //Service = await _context.Services.Include(s => s.EmployeeNavigation).ToListAsync();
    }
}
