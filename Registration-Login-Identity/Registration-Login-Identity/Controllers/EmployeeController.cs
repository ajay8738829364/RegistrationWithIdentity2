using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Registration_Login_Identity.Data;
using Registration_Login_Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration_Login_Identity.Controllers
{
    public class EmployeeController : Controller
    {
        public IEmployee _Employee { get; }
        public ApplicationDbContext Context { get; }

        public EmployeeController(IEmployee employee,ApplicationDbContext context)
        {
            _Employee = employee;
            Context = context;
        }

        

        public IActionResult Index()
        {
            var emp = _Employee.GetEmployeeList();
            return View(emp);
        }
        public IActionResult CreateEmp()
        {

            ViewBag.deptDdl = new SelectList(Context.departments, "Id", "DeptName");
            return View();
        }
        [HttpPost]
        public IActionResult CreateEmp(Employee employee)
        {
            var Dept=employee.DeptId;
            _Employee.AddEmployee(employee);
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            var q = _Employee.DeleteEmployee(id);
            if (q)
            {
                ViewBag.message = "Record Delete Successfull";
            }
            else
            {
                ViewBag.message = "Record Not  Deleted ";
            }
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            var q = _Employee.GetEmployeeWithId(id);
            return View(q);
        }
        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            _Employee.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }
    }
}
