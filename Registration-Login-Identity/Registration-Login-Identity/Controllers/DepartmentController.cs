using Microsoft.AspNetCore.Mvc;
using Registration_Login_Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration_Login_Identity.Controllers
{
    public class DepartmentController : Controller
    {
        public IDepartment _Department { get; }
        public DepartmentController(IDepartment department)
        {
            _Department = department;
        }

        

        public IActionResult Index()
        {
            var dept = _Department.GetDepartmentList();
            return View(dept);
        }
        public IActionResult CreateDept()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateDept( Department department)
        {
            _Department.AddDepartment(department);
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            var q = _Department.DeleteDepartment(id);
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
            var q = _Department.GetDepartmentWithId(id);
            return View(q);
        }
        [HttpPost]
        public IActionResult Update(Department department)
        {
            _Department.UpdateDepartment(department);
            return RedirectToAction("Index");
        }
    }
}
