using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration_Login_Identity.Models
{
   public interface IEmployee
    {
        IEnumerable<Employee> GetEmployeeList();
        Employee AddEmployee(Employee employee);
        Employee GetEmployeeWithId(int id);
        bool DeleteEmployee(int id);
        Employee UpdateEmployee(Employee employee);
        IEnumerable<Department> DeptList();
    }
}
