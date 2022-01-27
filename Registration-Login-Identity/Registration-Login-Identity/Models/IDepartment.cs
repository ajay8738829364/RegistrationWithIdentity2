using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration_Login_Identity.Models
{
   public interface IDepartment
    {
        IEnumerable<Department> GetDepartmentList();
        Department AddDepartment(Department department);
        Department GetDepartmentWithId(int id);
        bool DeleteDepartment(int id);
        Department UpdateDepartment(Department department);
    }
}
