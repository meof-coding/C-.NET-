using Bussiness_Object.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IEmployeeRepository
    {
        //get employee
        List<Employee> GetEmployees();
        //get employee by id
        Employee GetEmployee(int empId);
    }
}
