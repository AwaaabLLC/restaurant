using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataObjectLayer;
using MVCPresentationLayer.Data;
using ILogicLayer;
using LogicLayer;
using MVCPresentationLayer.Data.Migrations;

namespace MVCPresentationLayer.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesManager employeesManager;

        public EmployeesController()
        {
            employeesManager = new EmployeesManager();
        }

        // GET: Employees
        public ActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            employees = employeesManager.getAllEmployees();
            return View(employees);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee employee = employeesManager.getEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("EmployeeId,FirstName,LastName,CellPhone,EmailAddress")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                bool result = employeesManager.addNewEmployee(employee);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "There is something wrong. Please check it and try again";
                }
                
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee employee = employeesManager.getEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("EmployeeId,FirstName,LastName,CellPhone,EmailAddress")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bool result = employeesManager.updateEmployee(employee);
                }
                catch (Exception e)
                {
                    ViewBag.error = e.Message;
                }
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = employeesManager.getEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool result = employeesManager.deleteEmployee(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "There is something wrong. Please check it and try again";
                Employee employee = employeesManager.getEmployeeById(id);
                return View(employee);
            }
            
        }

        private bool EmployeeExists(int id)
        {
            return true;
        }
    }
}
