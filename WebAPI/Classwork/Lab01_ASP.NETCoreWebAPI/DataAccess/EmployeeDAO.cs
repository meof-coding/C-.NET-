using Bussiness_Object.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EmployeeDAO
    {
        //get employee
        public static List<Employee> GetEmployees()
        {
            var listEmployees = new List<Employee>();
            try
            {
                using (var context = new NorthwindContext())
                {
                    listEmployees = context.Employees.Include(e => e.ReportsToNavigation).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return listEmployees;
        }

        //get employee by id
        public static Employee GetEmployee(int empId)
        {
            Employee e = new Employee();
            try
            {
                using (var context = new NorthwindContext())
                {
                    e = context.Employees.Include(e => e.ReportsToNavigation).SingleOrDefault(x => x.EmployeeId == empId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return e;
        }
    }
}
