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

namespace MVCPresentationLayer.Controllers
{
    public class EmployeeUsersController : Controller
    {
        private IUsersManager employeesUsersManager;

        public EmployeeUsersController()
        {
            employeesUsersManager = new UsersManager();
        }

        // GET: EmployeeUsers
        public ActionResult Index()
        {
            List<EmployeeUser> employeeUsers = [];
            employeeUsers = employeesUsersManager.getAllEmployeesUsers();
            return View(employeeUsers);
        }

        // GET: EmployeeUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmployeeUser employeeUser = employeesUsersManager.getEmployeesUserById(id);
            if (employeeUser == null)
            {
                return NotFound();
            }

            return View(employeeUser);
        }

        // GET: EmployeeUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,EmailAddress,Pass,Active")] EmployeeUser employeeUser)
        {
            if (ModelState.IsValid)
            {
                bool result = employeesUsersManager.addNewEmployeeUser(employeeUser);
                return RedirectToAction(nameof(Index));
            }
            return View(employeeUser);
        }

        // GET: EmployeeUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmployeeUser employeeUser = employeesUsersManager.getEmployeesUserById(id);
            if (employeeUser == null)
            {
                return NotFound();
            }
            return View(employeeUser);
        }

        // POST: EmployeeUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,EmailAddress,Pass,Active")] EmployeeUser employeeUser)
        {
            if (id != employeeUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bool result = employeesUsersManager.updateEmployeeUser(employeeUser);
                }
                catch (Exception ex)
                {
                    ViewBag.error = ex.Message;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeUser);
        }

        // GET: EmployeeUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmployeeUser employeeUser = employeesUsersManager.getEmployeesUserById(id);
            if (employeeUser == null)
            {
                return NotFound();
            }

            return View(employeeUser);
        }

        // POST: EmployeeUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool result = false;
            EmployeeUser employeeUser = employeesUsersManager.getEmployeesUserById(id);
            if (employeeUser != null)
            {
                result = employeesUsersManager.deactiveActiveUser(employeeUser);
            }
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(employeeUser);
        }

        private bool EmployeeUserExists(int id)
        {
            return false;
        }
    }
}
