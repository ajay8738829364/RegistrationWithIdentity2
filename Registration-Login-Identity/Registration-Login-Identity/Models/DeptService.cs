using Registration_Login_Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration_Login_Identity.Models
{
    public class DeptService:IDepartment
    {
        public ApplicationDbContext _Context { get; }
        public DeptService(ApplicationDbContext context)
        {
            _Context = context;
        }

        public IEnumerable<Department> GetDepartmentList()
        {
            return _Context.departments.ToList();
        }

        public Department AddDepartment(Department department)
        {
            _Context.departments.Add(department);
            _Context.SaveChanges();
            return department;

        }

        public Department GetDepartmentWithId(int id)
        {
            var dept = _Context.departments.FirstOrDefault(e => e.Id == id);
            return dept;
        }

        public bool DeleteDepartment(int id)
        {
            if (_Context.departments.Any(e => e.Id == id))
            {
                var emp = _Context.departments.FirstOrDefault(e => e.Id == id);
                _Context.departments.Remove(emp);
                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Department UpdateDepartment(Department department)
        {
            var dept = _Context.departments.FirstOrDefault(e => e.Id == department.Id);
            dept.DeptName = department.DeptName;
            dept.CreatedDate = DateTime.Now;

            _Context.departments.Update(dept);
            _Context.SaveChanges();
            return dept;
        }
    }
}
