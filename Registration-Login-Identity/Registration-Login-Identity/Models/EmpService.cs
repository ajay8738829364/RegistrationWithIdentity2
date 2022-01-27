using Microsoft.AspNetCore.Mvc.Rendering;
using Registration_Login_Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration_Login_Identity.Models
{
    public class EmpService:IEmployee
    {
        public ApplicationDbContext _Context { get; }
        public EmpService(ApplicationDbContext context)
        {
            _Context = context;
        }

        public IEnumerable<Employee> GetEmployeeList()
        {
            return _Context.employees.ToList();
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.CreatedDate = DateTime.Now;
            _Context.employees.Add(employee);
            _Context.SaveChanges();

            return employee;
        }

        public Employee GetEmployeeWithId(int id)
        {
            var emp = _Context.employees.FirstOrDefault(e => e.empId == id);
            return emp;
        }

        public bool DeleteEmployee(int id)
        {

            if (_Context.employees.Any(e => e.empId == id))
            {
                var emp = _Context.employees.FirstOrDefault(e => e.empId == id);
                _Context.employees.Remove(emp);
                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var emp = _Context.employees.FirstOrDefault(e => e.empId == employee.empId);
            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.Email = employee.Email;
            emp.MobileNo = employee.MobileNo;
            emp.CreatedDate = DateTime.Now;

            _Context.employees.Update(emp);
            _Context.SaveChanges();
            return emp;
        }

        public IEnumerable<Department> DeptList()
        {
            var dept = (from i in _Context.departments
                        select new SelectListItem()
                        {
                            Text=i.DeptName,
                            Value=i.Id.ToString()
                        }).ToList();
            dept.Insert(0, new SelectListItem { Value=string.Empty, Text = "Select" });
            return (IEnumerable<Department>)dept;
        }
    }
}
