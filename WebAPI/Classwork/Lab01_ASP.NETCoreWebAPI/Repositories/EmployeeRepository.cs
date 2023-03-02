using Bussiness_Object.DataAccess;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Employee GetEmployee(int empId)
        {
            return EmployeeDAO.GetEmployee(empId);
        }

        public List<Employee> GetEmployees()
        {
            return EmployeeDAO.GetEmployees();
        }
    }
}
