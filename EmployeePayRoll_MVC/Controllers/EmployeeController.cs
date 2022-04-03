using BusinessLayer.Interface;
using CommonLayer;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayRoll_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeBL employeeBL;
        public EmployeeController(IEmployeeBL employeeBL)
        {
            this.employeeBL = employeeBL;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<EmployeeModel> lstEmployee = new List<EmployeeModel>();
            lstEmployee = employeeBL.GetAllEmployees().ToList();

            return View(lstEmployee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                employeeBL.AddEmployee(employeeModel);
                return RedirectToAction("Index");
            }
            return View(employeeModel);
        }
        //Edit Employee Controller
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employeeModel = employeeBL.GetEmployeeData(id);

            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] EmployeeModel employeeModel)
        {
            if (id != employeeModel.EmployeeID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employeeBL.UpdateEmployee(employeeModel);
                return RedirectToAction("Index");
            }
            return View(employeeModel);
        }
        //details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employeeModel= employeeBL.GetEmployeeData(id);

            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }
        //delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employeeModel= employeeBL.GetEmployeeData(id);

            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            employeeBL.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

    }
}
