using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bussiness_Object.DataAccess;
using System.Xml.Serialization;

namespace ProductManagementWebClient.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly HttpClient client = null;
        private string EmployeeApiUrl = "";

        public EmployeesController()
        {
            client = new HttpClient();
            EmployeeApiUrl = "https://localhost:7118/api/employees";
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(EmployeeApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            //var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            //List<Employee> employees = JsonSerializer.Deserialize<List<Employee>>(strData, options);
            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            Employee employee = (Employee)serializer.Deserialize(new StringReader(strData));
            return View(employee);
        }

    }
}
